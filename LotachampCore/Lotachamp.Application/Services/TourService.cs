using Lotachamp.Application.Interfaces;
using Lotachamp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lotachamp.Application.Services
{
    public class TourService
    {
        private readonly ILotachampContext _ctx;

        public TourService(ILotachampContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Tour> GetAll(bool onlyPublic = false)
        {
            return GetEnded(onlyPublic)
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

        public IEnumerable<Tour> GetOngoingForUser(int appUserId)
        {
            //TODO: Only return tours the user is member of, is official in or admin in
            return _ctx.Tours
                .Where(o => o.StartDate <= DateTime.Now && o.EndDate >= DateTime.Now)
                .AsEnumerable();
        }

        public IEnumerable<Tour> GetEnded(bool onlyPublic = false)
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
