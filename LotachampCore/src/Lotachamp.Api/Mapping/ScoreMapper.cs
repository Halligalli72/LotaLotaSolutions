using Lotachamp.Api.ViewModels;
using Lotachamp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lotachamp.Api.Mapping
{
    public static class ScoreMapper
    {
        public static ScoreVM AsViewModel(this Score obj)
        {
            return new List<Score> { obj }.AsViewModels().Single();
        }

        public static IEnumerable<ScoreVM> AsViewModels(this IEnumerable<Score> entities)
        {
            return from e in entities
                   select new ScoreVM
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
