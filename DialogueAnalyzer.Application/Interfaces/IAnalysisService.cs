using DialogueAnalyzer.Domain;

namespace DialogueAnalyzer.Application.Interfaces
{
    public interface IAnalysisService
    {
        Task<Result<AnalysisResult>> ProcessRequestAsync(Guid userProfileId, Guid partnerProfileId, string rawText);
    }
}
