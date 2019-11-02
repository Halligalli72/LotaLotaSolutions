using Lotachamp.Application.Interfaces;
using Lotachamp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lotachamp.Application.Services
{
    public class ScoreService
    {
        private readonly ILotachampContext _ctx;
        public ScoreService(ILotachampContext ctx) 
        {
            _ctx = ctx;
        }

        public IEnumerable<Score> GetAll() 
        {
            return _ctx.Scores.AsEnumerable();
        }

        public IEnumerable<Score> GetByTour(int tourId)
        {
            return _ctx.Scores
                .Where(o => o.Sport.TourId.Equals(tourId))
                .AsEnumerable();
        }

        public IEnumerable<Score> GetLatest(int limit)
        {
            return _ctx.Scores
                .OrderByDescending(o => o.Created)
                .Take(limit)
                .AsEnumerable();
        }

        public IEnumerable<Score> GetLatest(int tourId, int limit)
        {
            return _ctx.Scores
                .Where(o => o.Sport.TourId.Equals(tourId))
                .OrderByDescending(o => o.Created)
                .Take(limit)
                .AsEnumerable();
        }

        public Score GetById(Guid scoreId) 
        {
            return _ctx.Scores
                .Where(o => o.ScoreId.Equals(scoreId))
                .FirstOrDefault();
        }
    }
}
