using Lotachamp.Application.Interfaces;
using Lotachamp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lotachamp.Application.Services
{
    public interface ISportService
    {
        IEnumerable<Sport> GetAll();
        Sport GetById(int sportId);
        IEnumerable<Sport> GetByTour(int tourId);
    }

    public class SportService : ISportService
    {
        private readonly ILotachampContext _ctx;

        public SportService(ILotachampContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Sport> GetAll()
        {
            return _ctx.Sports
                .Include(s => s.Measurement)
                .Include(s => s.RankAlgorithm)
                .AsEnumerable();
        }

        public Sport GetById(int sportId)
        {
            return _ctx.Sports
                .Include(s => s.Measurement)
                .Include(s => s.RankAlgorithm)
                .Where(o => o.SportId.Equals(sportId)).FirstOrDefault();
        }

        public IEnumerable<Sport> GetByTour(int tourId)
        {
            return _ctx.Sports.Where(o => o.TourId.Equals(tourId))
                .Include(s => s.Measurement)
                .Include(s => s.RankAlgorithm)
                .AsEnumerable();
        }

    }
}
