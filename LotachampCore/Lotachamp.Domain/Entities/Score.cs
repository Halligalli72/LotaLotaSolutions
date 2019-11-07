using System;
using System.Collections.Generic;
using System.Text;

namespace Lotachamp.Domain.Entities
{
    public class Score : BaseEntity
    {
        public Score()
        {
            Notes = string.Empty;
            Created = DateTime.Now;
            Pictures = new HashSet<Picture>();
        }

        public Guid ScoreId { get; set; }
        public int SportId { get; set; }
        public Guid ParticipantId { get; set; }
        public int ResultValue { get; set; }
        public DateTime ScoreDate { get; set; }
        public string Notes { get; set; }

        public virtual ICollection<Picture> Pictures { get; set; }
        public virtual Sport Sport { get; set; }
        public virtual Participant Participant { get; set; }
    }
}
