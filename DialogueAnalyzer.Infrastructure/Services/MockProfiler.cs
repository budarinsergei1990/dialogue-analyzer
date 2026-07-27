using DialogueAnalyzer.Application.Interfaces;
using DialogueAnalyzer.Domain;

namespace DialogueAnalyzer.Infrastructure.Services
{
    public class MockProfiler : IParticipantProfiler
    {
        public Task<Result<ParticipantProfile>> CreateProfileAsync(string displayName, string description)
        {
            var traits = new MetaTraits(dominance: 0.3, empathy: 0.8, anxiety: 0.4, impulsivity: 0.3, analyticity: 0.6);
            ParticipantProfile profile = new ParticipantProfile(displayName, traits);
            return Task.FromResult(Result<ParticipantProfile>.Success(profile));
        }
    }
}
