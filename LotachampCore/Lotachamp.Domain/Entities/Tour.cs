using Lotachamp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lotachamp.Domain.Entities
{
    public class Tour : BaseEntity
    {
        public Tour()
        {
            Name = string.Empty;
            Description = string.Empty;
            Sports = new HashSet<Sport>();
            Participants = new HashSet<Participant>();
            IsPublic = false;
            Created = DateTime.Now;
        }

        public int TourId { get; set; }
        public string Name { get; set; } 
        public string Description { get; set; } 
        public bool IsPublic { get; set; }
        public DateTime StartDate { get; set; } 
        public DateTime EndDate { get; set; } 

        public virtual ICollection<Sport> Sports { get; private set; }
        public virtual ICollection<Participant> Participants { get; private set; }

    }
}
