using Lotachamp.Application.BusinessObjects;
using Lotachamp.Application.Infrastructure;
using Lotachamp.Application.Ranking;
using Lotachamp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lotachamp.Application.Services
{
    public interface IScoreService
    {
        IEnumerable<Score> GetAll();
        Score GetById(Guid scoreId);
        IEnumerable<Score> GetByTour(int tourId);
        IEnumerable<Score> GetLatest(int limit);
        IEnumerable<Score> GetLatest(int tourId, int limit);
    }

    public class ScoreService : IScoreService
    {
        private readonly ILotachampContext _ctx;
        private readonly IRankEngine _rankEngine;

        public ScoreService(ILotachampContext ctx, IRankEngine rankEngine)
        {
            _ctx = ctx;
            _rankEngine = rankEngine;
        }

        public IEnumerable<Score> GetAll()
        {
            return _rankEngine.Rank(_ctx.Scores.AsEnumerable());
        }

        public IEnumerable<Score> GetByTour(int tourId)
        {
            return _rankEngine.Rank(_ctx.Scores
                .Where(o => o.Sport.TourId.Equals(tourId))
                .AsEnumerable());
        }

        public IEnumerable<Score> GetLatest(int limit)
        {
            return _rankEngine.Rank(_ctx.Scores
                .OrderByDescending(o => o.Created)
                .Take(limit)
                .AsEnumerable());
        }

        public IEnumerable<Score> GetLatest(int tourId, int limit)
        {
            return _rankEngine.Rank(_ctx.Scores
                .Where(o => o.Sport.TourId.Equals(tourId))
                .OrderByDescending(o => o.Created)
                .Take(limit)
                .AsEnumerable());
        }

        public Score GetById(Guid scoreId)
        {
            return _rankEngine.Rank(_ctx.Scores
                .Where(o => o.ScoreId.Equals(scoreId))
                .FirstOrDefault());
        }
    }
}
