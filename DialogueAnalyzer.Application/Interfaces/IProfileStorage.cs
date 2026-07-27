using DialogueAnalyzer.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DialogueAnalyzer.Application.Interfaces
{
    public interface IProfileStorage
    {
        Task<Result<bool>> SaveProfileAsync(ParticipantProfile profile);  

        Task<Result<bool>> SaveProfilePairAsync(ParticipantProfile user, ParticipantProfile partner);  

        Task<Result<ParticipantProfile>> GetProfileByIdAsync(Guid profileId);

        Task<Result<(ParticipantProfile user, ParticipantProfile partner)>> GetProfilePairAsync(Guid userProfileId, Guid partnerProfileId);

        Task<Result<AnalysisRecord>> SaveAnalysisRecordAsync(AnalysisRecord record);

        Task<Result<IReadOnlyList<AnalysisRecord>>> GetAnalysisHistoryAsync(Guid userProfileId, Guid partnerProfileId);
    }
}
