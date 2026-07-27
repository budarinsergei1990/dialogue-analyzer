namespace DialogueAnalyzer.Domain
{
    public class AnalysisContext
    {
        public ParticipantProfile ProfileA { get; private set; }
        public ParticipantProfile ProfileB { get; private set; }
        public Dialogue Dialogue { get; private set; }
        public Message Message { get; private set; }
        public AnalysisResult Result { get; set; }  
        public IReadOnlyList<string> Intents { get; set; }
        public string DialogueArc { get; set; }

        private AnalysisContext (ParticipantProfile profilea, ParticipantProfile profileb)
        {
            if (profilea == null )
                throw new ArgumentNullException(nameof(profilea));
            ProfileA = profilea;

            if (profileb == null)
                throw new ArgumentNullException(nameof(profileb));
            ProfileB = profileb;
        }

        public AnalysisContext(ParticipantProfile profilea, ParticipantProfile profileb, Message message) : this (profilea, profileb)
        {
            if (message == null)
                throw new ArgumentNullException(nameof(message));
            Message = message;
        }

        public AnalysisContext(ParticipantProfile profilea, ParticipantProfile profileb, Dialogue dialogue) : this(profilea, profileb)
        {
            if (dialogue == null)
                throw new ArgumentNullException(nameof(dialogue));
            Dialogue = dialogue;
        }
    }
}
