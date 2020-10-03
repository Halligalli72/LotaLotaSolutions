using Lotachamp.Api.ViewModels;
using Lotachamp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lotachamp.Api.Mapping
{
    public static class TournamentMapper
    {
        public static TournamentVM AsViewModel(this Tournament obj)
        {
            return new List<Tournament> { obj }.AsViewModels().Single();
        }

        public static IEnumerable<TournamentVM> AsViewModels(this IEnumerable<Tournament> entities)
        {
            return from e in entities
                   select new TournamentVM
                   {
                       TourId = e.TournamentId,
                       Name = e.Name,
                       Description = e.Description,
                       IsPublic = e.IsPublic,
                       StartDate = e.StartDate,
                       EndDate = e.EndDate,
                       Created = e.Created,
                       CreatedBy = e.CreatedBy,
                       Updated = e.Updated,
                       UpdatedBy = e.UpdatedBy
                   };
        }

    }
}
