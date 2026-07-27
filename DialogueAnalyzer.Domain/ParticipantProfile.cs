using System;
using System.Collections.Generic;
using System.Text;

namespace DialogueAnalyzer.Domain
{
    public class ParticipantProfile
    {
        public Guid Id { get; private set; }
        public string DisplayName { get; private set; }
        public MetaTraits Traits { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public string? Description { get; private set; } // описание партнёра 

        public ParticipantProfile(string displayName, MetaTraits traits)
        {
            if (traits == null)
                throw new ArgumentNullException(nameof(traits));
            Traits = traits;

            if (string.IsNullOrEmpty(displayName))
                throw new ArgumentException("Имя не может быть пустым", nameof(displayName));
            DisplayName = displayName;

            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public void ApplyChange(ProfileChange change)
        {
            if (change == null)
                throw new ArgumentNullException(nameof(change));

            Traits.ApplyDelta(change.Delta);
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
