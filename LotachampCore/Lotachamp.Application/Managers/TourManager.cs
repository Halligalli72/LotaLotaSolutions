using Lotachamp.Application.Interfaces;
using Lotachamp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lotachamp.Application.Managers
{
    public class TourManager
    {
        private readonly ILotachampContext _ctx;

        public TourManager(ILotachampContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Tour> GetAll(bool onlyPublic = false)
        {
            return GetPassed(onlyPublic)
                .Concat(GetOngoing(onlyPublic)
                .Concat(GetFuture(onlyPublic)));
        }

        public Tour GetById(int tourId, bool onlyPublic = false)
        {
            return _ctx.Tours
                .Where(o => o.TourId.Equals(tourId) && o.IsPublic.Equals(onlyPublic)).FirstOrDefault();
        }

        public IEnumerable<Tour> GetOngoing(bool onlyPublic = false)
        {
            return _ctx.Tours
                .Where(o => o.StartDate <= DateTime.Now && o.EndDate >= DateTime.Now && o.IsPublic.Equals(onlyPublic))
                .AsEnumerable();
        }

        public IEnumerable<Tour> GetPassed(bool onlyPublic = false)
        {
            return _ctx.Tours
                .Where(o => o.EndDate < DateTime.Now && o.IsPublic.Equals(onlyPublic))
                .AsEnumerable();
        }

        public IEnumerable<Tour> GetFuture(bool onlyPublic = false)
        {
            return _ctx.Tours
                .Where(o => o.StartDate > DateTime.Now && o.IsPublic.Equals(onlyPublic))
                .AsEnumerable();
        }
    }
}
