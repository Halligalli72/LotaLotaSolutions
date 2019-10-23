using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotachamp.Model
{
    public class Tour
    {
        public int TourId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsPublic { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public System.DateTime Updated { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public virtual List<SportEvent> SportEvents { get; set; }
        public virtual List<Participant> Participants { get; set; }

        public Tour()
        {
            IsPublic = false;
            Updated = DateTime.Parse("1900-01-01");
            UpdatedBy = "";
            Created = DateTime.Now;
        }
    }
}
