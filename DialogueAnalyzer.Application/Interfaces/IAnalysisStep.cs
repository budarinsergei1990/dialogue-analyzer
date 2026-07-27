using DialogueAnalyzer.Domain;

namespace DialogueAnalyzer.Application.Interfaces
{
    public interface IAnalysisStep
    {
        Task<Result<AnalysisContext>> ExecuteAsync(AnalysisContext context);
    }
}
