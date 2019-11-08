using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lotachamp.Api.DataTransfer
{
    public class CreateScoreDto
    {
        public int TourId { get; set; }
        public Guid ParticipantId { get; set; }
        public int SportId { get; set; }
        public DateTime ScoreDate { get; set; }
        public int ResultValue { get; set; }
        public string Notes { get; set; }

    }
}
