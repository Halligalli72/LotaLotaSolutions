using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lotachamp.Api.ViewModels
{
    /// <summary>
    /// View model for create/update score form
    /// </summary>
    [Serializable]
    public class ScoreFormVM
    {
        public int TourId { get; set; }
        public Guid ParticipantId { get; set; }
        public int SportId { get; set; }
        public DateTime ScoreDate { get; set; }
        public int ResultValue { get; set; }
        public string Notes { get; set; }
        public string CreatedBy { get; set; }

    }
}
