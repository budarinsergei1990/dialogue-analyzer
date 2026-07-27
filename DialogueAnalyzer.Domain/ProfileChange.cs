namespace DialogueAnalyzer.Domain
{
    public class ProfileChange
    {
        public Guid Id { get; private set; }
        public Guid ProfileId { get; private set; }
        public MetaTraits Delta { get; private set; }
        public DateTime Timestamp { get; private set; }
        public string Source { get; private set; }

        public ProfileChange(Guid profileId, MetaTraits delta, string source)
        {
            if (delta == null)
                throw new ArgumentNullException(nameof(delta));
            Delta = delta;

            if (string.IsNullOrEmpty(source))
                throw new ArgumentException("Source не может быть пустым", nameof(source));
            Source = source;

            Id = Guid.NewGuid();
            ProfileId = profileId;
            Timestamp = DateTime.UtcNow;
        }
    }
}
