using Lotachamp.Application.BusinessObjects;
using Lotachamp.Application.Interfaces;
using Lotachamp.Application.Ranking;
using Lotachamp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lotachamp.Application.Services
{
    public interface IScoreService
    {
        IEnumerable<ScoreBO> GetAll();
        ScoreBO GetById(Guid scoreId);
        IEnumerable<ScoreBO> GetByTour(int tourId);
        IEnumerable<ScoreBO> GetLatest(int limit);
        IEnumerable<ScoreBO> GetLatest(int tourId, int limit);
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

        public IEnumerable<ScoreBO> GetAll()
        {
            return _rankEngine.Rank(_ctx.Scores.AsEnumerable());
        }

        public IEnumerable<ScoreBO> GetByTour(int tourId)
        {
            return _rankEngine.Rank(_ctx.Scores
                .Where(o => o.Sport.TourId.Equals(tourId))
                .AsEnumerable());
        }

        public IEnumerable<ScoreBO> GetLatest(int limit)
        {
            return _rankEngine.Rank(_ctx.Scores
                .OrderByDescending(o => o.Created)
                .Take(limit)
                .AsEnumerable());
        }

        public IEnumerable<ScoreBO> GetLatest(int tourId, int limit)
        {
            return _rankEngine.Rank(_ctx.Scores
                .Where(o => o.Sport.TourId.Equals(tourId))
                .OrderByDescending(o => o.Created)
                .Take(limit)
                .AsEnumerable());
        }

        public ScoreBO GetById(Guid scoreId)
        {
            return _rankEngine.Rank(_ctx.Scores
                .Where(o => o.ScoreId.Equals(scoreId))
                .FirstOrDefault());
        }
    }
}
