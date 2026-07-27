namespace DialogueAnalyzer.Domain
{
    public class AnalysisRecord
    {
        public Dialogue Dialogue { get; private set; }
        public AnalysisResult Result { get; private set; }
        public Guid Id { get; private set; }
        public Guid UserProfileId { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public AnalysisRecord(Guid userprofileid, Dialogue dialogue, AnalysisResult result)
        {

            if (dialogue == null)
                throw new ArgumentNullException(nameof(dialogue));
            if (result == null)
                throw new ArgumentNullException(nameof(result));
            if (userprofileid == Guid.Empty)
                throw new ArgumentException("...", nameof(userprofileid));

            Dialogue = dialogue;
            UserProfileId = userprofileid;
            Result = result;
            CreatedAt = DateTime.UtcNow;
            Id = Guid.NewGuid();
        }
    }
}
