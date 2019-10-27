using Lotachamp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lotachamp.Api.DataTransfer
{
    public class SportDto
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

    public static class SportDtoBuilder
    {
        public static SportDto AsDto(this Sport obj)
        {
            return new List<Sport> { obj }.AsDtos().Single();
        }

        public static IEnumerable<SportDto> AsDtos(this IEnumerable<Sport> entities)
        {
            return from e in entities
                   select new SportDto
                   {
                       SportId = e.SportId,
                       TourId = e.TourId,
                       Name = e.Name,
                       RankAlgorithmId = e.RankAlgorithmId,
                       RankAlgorithmName = e.RankAlgorithm.Name,   
                       MeasurementId = e.MeasurementId,
                       MeasurementName = e.Measurement.Name,
                       PictureRequired = e.PictureRequired,
                       P1 = e.P1,
                       P2 = e.P2,
                       P3 = e.P3,
                       P4 = e.P4,
                       P5 = e.P5,
                       SeedPoint = e.SeedPoint,
                       Created = e.Created,
                       CreatedBy = e.CreatedBy,
                       Updated = e.Updated,
                       UpdatedBy = e.UpdatedBy
                   };
        }
    }


}
