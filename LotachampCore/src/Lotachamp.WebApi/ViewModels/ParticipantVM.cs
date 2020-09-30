using Lotachamp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lotachamp.Api.ViewModels
{
    /// <summary>
    /// View model for a participant
    /// </summary>
    public class ParticipantVM
    {
        public Guid ParticipantId { get; set; } = Guid.Empty;
        public int TourId { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public string Alias { get; set; } = string.Empty;
        public bool IsCompeting { get; set; } = false;
        public bool IsTourAdmin { get; set; } = false;
        public bool IsTourOfficial { get; set; } = false;
        public int TotalPoints { get; set; }
        public int TotalRank { get; set; }

        public DateTime Created { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime? Updated { get; set; }
        public string UpdatedBy { get; set; } = string.Empty;
    }

    public static class ParticipantDtoBuilder
    {
        public static ParticipantVM AsDto(this Participant obj)
        {
            return new List<Participant> { obj }.AsDtos().Single();
        }

        public static IEnumerable<ParticipantVM> AsDtos(this IEnumerable<Participant> entities)
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
