﻿using Lotachamp.Api.ViewModels;
using Lotachamp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lotachamp.Api.Mapping
{
    public static class TourMapper
    {
        public static TourVM AsViewModel(this Tour obj)
        {
            return new List<Tour> { obj }.AsViewModels().Single();
        }

        public static IEnumerable<TourVM> AsViewModels(this IEnumerable<Tour> entities)
        {
            return from e in entities
                   select new TourVM
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
