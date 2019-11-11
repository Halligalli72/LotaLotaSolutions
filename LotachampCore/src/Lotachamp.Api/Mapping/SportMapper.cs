using Lotachamp.Api.ViewModels;
using Lotachamp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lotachamp.Api.Mapping
{
    public static class SportMapper
    {
        public static SportVM AsViewModel(this Sport obj)
        {
            return new List<Sport> { obj }.AsViewModels().Single();
        }

        public static IEnumerable<SportVM> AsViewModels(this IEnumerable<Sport> entities)
        {
            return from e in entities
                   select new SportVM
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
