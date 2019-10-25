using System;
using System.Collections.Generic;
using System.Text;

namespace Lotachamp.Domain.Entities
{
    public class Participant : BaseEntity
    {
        public Participant()
        {
            IsTourAdmin = false;
            IsTourOfficial = false;
            IsCompeting = true;
            Scores = new HashSet<Score>();
            Created = DateTime.Now;
        }

        public Guid ParticipantId { get; set; }
        public int TourId { get; set; }
        public int InviteId { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public bool IsCompeting { get; set; }
        public bool IsTourAdmin { get; set; }
        public bool IsTourOfficial { get; set; }

        public virtual Invite Invite { get; set; }
        public virtual Tour Tour { get; set; }
        public virtual ICollection<Score> Scores { get; private set; }
    }
}
