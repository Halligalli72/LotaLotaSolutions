using System;
using System.Collections.Generic;
using System.Text;

namespace Lotachamp.Domain.Entities
{
    public class Invite : BaseEntity
    {
        public Invite()
        {
            Activated = false;
            CanInvite = false;
            InviteLimit = 0;
            Created = DateTime.Now;
        }

        public Guid InviteId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool Activated { get; set; }
        public Guid InvitedBy { get; set; }
        public bool CanInvite { get; set; }
        public int InviteLimit { get; set; }
    }
}
