namespace DialogueAnalyzer.Domain
{
    public class BehavioralReport
    {
        public MetaTraits ObservedTraits { get; private set; }

        public BehavioralReport(MetaTraits observed)
        {
            if (observed == null)
                throw new ArgumentNullException(nameof(observed));
            ObservedTraits = observed;
        }
    }
}
