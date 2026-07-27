using DialogueAnalyzer.Application.Interfaces;
using DialogueAnalyzer.Domain;
using System.Collections.Concurrent;

namespace DialogueAnalyzer.Infrastructure.Services
{
    public class InMemoryProfileStorage : IProfileStorage
    {
        private readonly ConcurrentDictionary<Guid, ParticipantProfile> _profiles = new();
        private readonly ConcurrentDictionary<Guid, Guid> _pairs = new();
        private readonly ConcurrentDictionary<Guid, List<AnalysisRecord>> _history = new();

        public Task<Result<bool>> SaveProfileAsync(ParticipantProfile profile)
        {
            _profiles[profile.Id] = profile;
            return Task.FromResult(Result<bool>.Success(true));
        }

        public Task<Result<bool>> SaveProfilePairAsync(ParticipantProfile user, ParticipantProfile partner)
        {
            _profiles[user.Id] = user;
            _profiles[partner.Id] = partner;
            _pairs[user.Id] = partner.Id;
            return Task.FromResult(Result<bool>.Success(true));
        }

        public Task<Result<(ParticipantProfile user, ParticipantProfile partner)>> GetProfilePairAsync(Guid userProfileId, Guid partnerProfileId)
        {
            if (_profiles.TryGetValue(userProfileId, out var userProfile) &&
                _profiles.TryGetValue(partnerProfileId, out var partnerProfile))
            {
                return Task.FromResult(Result<(ParticipantProfile, ParticipantProfile)>.Success((userProfile, partnerProfile)));
            }

            return Task.FromResult(Result<(ParticipantProfile, ParticipantProfile)>.Failure("PAIR_NOT_FOUND", "Пара пользователь-парнёр не найдены"));
        }

        public Task<Result<ParticipantProfile>> GetProfileByIdAsync(Guid profileId)
        {
            if (_profiles.TryGetValue(profileId, out var profile))
                return Task.FromResult(Result<ParticipantProfile>.Success(profile));

            return Task.FromResult(Result<ParticipantProfile>.Failure("PROFILE_NOT_FOUND", "Профиль не найден"));
        }

        public Task<Result<AnalysisRecord>> SaveAnalysisRecordAsync(AnalysisRecord record)
        {
            _history.AddOrUpdate(
    record.UserProfileId,
    new List<AnalysisRecord> { record },
    (key, list) => { list.Add(record); return list; }
);
            return Task.FromResult(Result<AnalysisRecord>.Success(record));
        }

        public Task<Result<IReadOnlyList<AnalysisRecord>>> GetAnalysisHistoryAsync(Guid userProfileId, Guid partnerProfileId)
        {
            if (_history.TryGetValue(userProfileId, out var historyList))
            {
                return Task.FromResult(Result<IReadOnlyList<AnalysisRecord>>.Success(historyList));
            }

            return Task.FromResult(Result<IReadOnlyList<AnalysisRecord>>.Success(new List<AnalysisRecord>()));
        }
    }
}

