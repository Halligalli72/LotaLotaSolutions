using Lotachamp.Api.ViewModels;
using Lotachamp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lotachamp.Api.Mapping
{
    public static class ParticipantMapper
    {
        public static ParticipantVM AsViewModel(this Participant obj)
        {
            return new List<Participant> { obj }.AsViewModels().Single();
        }

        public static IEnumerable<ParticipantVM> AsViewModels(this IEnumerable<Participant> entities)
        {
            return from e in entities
                   select new ParticipantVM
                   {
                       ParticipantId = e.ParticipantId,
                       TourId = e.TourId,
                       Name = e.Name,
                       Alias = e.Alias,
                       IsCompeting = e.IsCompeting,
                       IsTourOfficial = e.IsTourOfficial,
                       IsTourAdmin = e.IsTourAdmin,
                       Created = e.Created,
                       CreatedBy = e.CreatedBy,
                       Updated = e.Updated,
                       UpdatedBy = e.UpdatedBy
                   };
        }
    }
}
