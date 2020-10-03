using Lotachamp.Application.Infrastructure;
using Lotachamp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lotachamp.Application.Services
{
    public interface ITournamentService
    {
        IEnumerable<Tournament> GetAll(bool onlyPublic = false);
        Tournament GetById(int tourId, bool onlyPublic = false);
        IEnumerable<Tournament> GetEnded(bool onlyPublic = false);
        IEnumerable<Tournament> GetFuture(bool onlyPublic = false);
        IEnumerable<Tournament> GetOngoing(bool onlyPublic = false);
        IEnumerable<Tournament> GetOngoingForUser(int appUserId);
    }

    public class TournamentService : ITournamentService
    {
        private readonly ILotachampContext _ctx;

        public TournamentService(ILotachampContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Tournament> GetAll(bool onlyPublic = false)
        {
            return GetEnded(onlyPublic)
                .Concat(GetOngoing(onlyPublic)
                .Concat(GetFuture(onlyPublic)));
        }

        public Tournament GetById(int tourId, bool onlyPublic = false)
        {
            return _ctx.Tours
                .Where(o => o.TournamentId.Equals(tourId) && o.IsPublic.Equals(onlyPublic)).FirstOrDefault();
        }

        public IEnumerable<Tournament> GetOngoing(bool onlyPublic = false)
        {
            return _ctx.Tours
                .Where(o => o.StartDate <= DateTime.Now && o.EndDate >= DateTime.Now && o.IsPublic.Equals(onlyPublic))
                .AsEnumerable();
        }

        public IEnumerable<Tournament> GetOngoingForUser(int appUserId)
        {
            //TODO: Only return tournaments that the user is member of, is official in or admin in
            return _ctx.Tours
                .Where(o => o.StartDate <= DateTime.Now && o.EndDate >= DateTime.Now)
                .AsEnumerable();
        }

        public IEnumerable<Tournament> GetEnded(bool onlyPublic = false)
        {
            return _ctx.Tours
                .Where(o => o.EndDate < DateTime.Now && o.IsPublic.Equals(onlyPublic))
                .AsEnumerable();
        }

        public IEnumerable<Tournament> GetFuture(bool onlyPublic = false)
        {
            return _ctx.Tours
                .Where(o => o.StartDate > DateTime.Now && o.IsPublic.Equals(onlyPublic))
                .AsEnumerable();
        }
    }
}
