namespace DialogueAnalyzer.Domain
{
    public class Dialogue
    {
        public Guid Id { get; private set; }
        public IReadOnlyList<Message> Messages { get; private set; }

        public Dialogue(IReadOnlyList<Message> messages)
        {
            if (messages == null || messages.Count == 0)
                throw new ArgumentException("Collection cannot be null or empty", nameof(messages));
            Messages = messages;

            Id = Guid.NewGuid();
        }
    }
}
