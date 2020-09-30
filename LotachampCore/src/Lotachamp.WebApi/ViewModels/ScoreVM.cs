using Lotachamp.Application.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lotachamp.Api.ViewModels
{
    /// <summary>
    /// View model for a score
    /// </summary>
    public class ScoreVM
    {
        public Guid ScoreId { get; set; }
        public int TourId { get; set; }
        public DateTime ScoreDate { get; set; }
        public int ResultValue { get; set; }
        public string ResultUnit { get; set; } = string.Empty;
        public string ParticipantName { get; set; } = string.Empty;
        public string SportName { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string ImageText { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public int Points { get; set; }
        public int Rank { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime? Updated { get; set; }
        public string UpdatedBy { get; set; } = string.Empty;
    }

}
