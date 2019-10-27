using Lotachamp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lotachamp.Api.DataTransfer
{
    public class ParticipantDto
    {
        public Guid ParticipantId { get; set; } = Guid.Empty;
        public int TourId { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public string Alias { get; set; } = string.Empty;
        public bool IsCompeting { get; set; } = false;
        public bool IsTourAdmin { get; set; } = false;
        public bool IsTourOfficial { get; set; } = false;
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime? Updated { get; set; }
        public string UpdatedBy { get; set; } = string.Empty;
    }

    public static class ParticipantDtoBuilder
    {
        public static ParticipantDto AsDto(this Participant obj)
        {
            return new List<Participant> { obj }.AsDtos().Single();
        }

        public static IEnumerable<ParticipantDto> AsDtos(this IEnumerable<Participant> entities)
        {
            return from e in entities
                   select new ParticipantDto
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
