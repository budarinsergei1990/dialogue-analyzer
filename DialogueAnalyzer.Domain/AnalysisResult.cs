namespace DialogueAnalyzer.Domain
{
    public class AnalysisResult
    {
        public string PartnerInterpretation { get; private set; }
        public IReadOnlyList<string> Recommendations { get; private set; }
        public double ConflictScore { get; private set; }
        public BehavioralReport? ObservedTraits { get; private set; }

        public AnalysisResult(string partnerInterpretation, IReadOnlyList<string> recommendations, double conflictScore, BehavioralReport? observedTraits = null)
        {

            if (conflictScore < 0 || conflictScore > 1)
                throw new ArgumentException("Значение не в тех диапазонх", nameof(conflictScore));
            ConflictScore = conflictScore;

            if (string.IsNullOrEmpty(partnerInterpretation))
                throw new ArgumentException("Интерпретация не может отсутсвоввать", nameof(partnerInterpretation));
            PartnerInterpretation = partnerInterpretation;

            if (recommendations == null || recommendations.Count == 0)
                throw new ArgumentException("Рекомендации не могут отсутсвоввать", nameof(recommendations));
            Recommendations = recommendations;

            ObservedTraits = observedTraits;
        }
    }
}
