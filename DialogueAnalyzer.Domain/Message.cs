namespace DialogueAnalyzer.Domain
{
    public class Message
    {
        public string Text { get; private set; }
        public DateTime TimeStamp { get; private set; }
        public Guid ProfileId { get; private set; }

        public Message(string text, DateTime timestamp, Guid profileId)
        {

            if (string.IsNullOrEmpty(text))
                throw new ArgumentException("Текст не может быть пустым", nameof(text));
            Text = text;

            if (profileId == Guid.Empty)
                throw new ArgumentException(nameof(profileId));
            ProfileId = profileId;

            if (timestamp.Year < 1970 || timestamp.Year > 2026)
                throw new ArgumentException("Дата не может быть меньше 1970 и больше 2026", nameof(timestamp));
            TimeStamp = timestamp;
        }
    }
}
