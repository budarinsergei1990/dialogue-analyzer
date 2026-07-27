using DialogueAnalyzer.Domain;

namespace DialogueAnalyzer.Application.Interfaces
{
    public interface IDialogueAnalyzer 
    {
        Task<Result<AnalysisResult>> AnalyzeAsync(AnalysisContext context);
    }
}
