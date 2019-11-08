using Lotachamp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lotachamp.Api.DataTransfer
{
    public class TourDto
    {
        public int TourId { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsPublic { get; set; } = false;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime? Updated { get; set; }
        public string UpdatedBy { get; set; } = string.Empty;
    }

    public static class TourDtoBuilder
    {
        public static TourDto AsDto(this Tour obj)
        {
            return new List<Tour> { obj }.AsDtos().Single();
        }

        public static IEnumerable<TourDto> AsDtos(this IEnumerable<Tour> entities)
        {
            return from e in entities
                   select new TourDto
                   {
                       TourId = e.TourId,
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
