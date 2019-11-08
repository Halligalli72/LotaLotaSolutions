using Lotachamp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lotachamp.Application.BusinessObjects
{
    public class ParticipantBO : Participant
    {
        public int? Rank { get; set; }
        public int Points { get; set; }

    }
}
