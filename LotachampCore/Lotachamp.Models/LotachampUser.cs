using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotachamp.Model
{
    public class LotachampUser
    {
        public int LotathlonUserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool Activated { get; set; }
        public bool CanCreateTour { get; set; }
        public bool CanInviteOthers { get; set; }
        public int InvitationLimit { get; set; }
        public string InvitedBy { get; set; }
        public System.DateTime Updated { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public LotachampUser()
        {
            Activated = false;
            CanCreateTour = false;
            CanInviteOthers = false;
            InvitationLimit = 0;
            InvitedBy = "";
            Updated = DateTime.Parse("1900-01-01");
            UpdatedBy = "";
            Created = DateTime.Now;
        }
    }
}
