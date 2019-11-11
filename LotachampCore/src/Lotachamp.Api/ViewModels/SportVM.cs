using Lotachamp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lotachamp.Api.ViewModels
{
    /// <summary>
    /// View model for a sport
    /// </summary>
    public class SportVM
    {
        public int SportId { get; set; } = 0;
        public int TourId { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public int RankAlgorithmId { get; set; } = 0;
        public string RankAlgorithmName { get; set; } = string.Empty;
        public int MeasurementId { get; set; } = 0;
        public string MeasurementName { get; set; } = string.Empty;
        public bool PictureRequired { get; set; } = false;
        public int P1 { get; set; } = 0;
        public int P2 { get; set; } = 0;
        public int P3 { get; set; } = 0;
        public int P4 { get; set; } = 0;
        public int P5 { get; set; } = 0;
        public int SeedPoint { get; set; } = 0;
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime? Updated { get; set; }
        public string UpdatedBy { get; set; } = string.Empty;

    }

}
