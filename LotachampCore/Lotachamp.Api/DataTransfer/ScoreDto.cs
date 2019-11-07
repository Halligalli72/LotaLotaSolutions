using Lotachamp.Application.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lotachamp.Api.DataTransfer
{
    /// <summary>
    /// Data transfer object for a score
    /// </summary>
    public class ScoreDto
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

    
    public static class ScoreDtoBuilder
    {
        public static ScoreDto AsDto(this ScoreBO obj) 
        {
            return new List<ScoreBO> { obj }.AsDtos().Single();
        }

        public static IEnumerable<ScoreDto> AsDtos(this IEnumerable<ScoreBO> entities) 
        {
            return from e in entities
                   select new ScoreDto 
                   {
                       ScoreId = e.ScoreId,
                       TourId = e.Sport.TourId,
                       ParticipantName = e.Participant.Name,
                       SportName = e.Sport.Name,
                       ResultValue = e.ResultValue,
                       ResultUnit = e.Sport.Measurement.ResultUnit,
                       Notes = e.Notes,
                       ImageUrl = e.Pictures?.FirstOrDefault().ImagePath,
                       ImageText = e.Pictures?.FirstOrDefault().ImageText,
                       Points = 0,
                       Rank = 0,
                       Created = e.Created,
                       CreatedBy = e.CreatedBy,
                       Updated = e.Updated,
                       UpdatedBy = e.UpdatedBy
                   };
        }
    }
}
