using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotachamp.Model
{
    public class Participant
    {
        public int ParticipantId { get; set; }
        public int TourId { get; set; }
        public int LotathlonUserId { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsCompeting { get; set; }
        public bool IsOfficial { get; set; }
        public System.DateTime Updated { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public Participant()
        {
            IsAdmin = false;
            IsCompeting = true;
            IsOfficial = false;
            Updated = DateTime.Parse("1900-01-01");
            UpdatedBy = "";
            Created = DateTime.Now;
        }
        public virtual LotachampUser LotathlonUser { get; set; }

        public virtual Tour Tour { get; set; }
    }
}
