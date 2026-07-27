using DialogueAnalyzer.Domain;

namespace DialogueAnalyzer.Application.Interfaces
{
    public interface IParticipantProfiler
    {
        Task<Result<ParticipantProfile>> CreateProfileAsync(string displayName, string description);
    }
}
