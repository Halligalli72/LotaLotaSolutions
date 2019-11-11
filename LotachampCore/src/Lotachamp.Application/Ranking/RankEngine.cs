using Lotachamp.Application.BusinessObjects;
using Lotachamp.Application.Infrastructure;
using Lotachamp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lotachamp.Application.Ranking
{
    public interface IRankEngine
    {
        IEnumerable<RankedScore> Rank(IEnumerable<Score> scores);
        RankedScore Rank(Score s);
    }

    public class RankEngine : IRankEngine
    {
        private readonly ILotachampContext _ctx;

        private IList<RankedScore> _rankedScores = new List<RankedScore>();

        private RankEngine() { }

        public RankEngine(ILotachampContext ctx)
        {
            _ctx = ctx;
        }

        public RankedScore Rank(Score s)
        {
            RankedScore ranked = _rankedScores.Where(o => o.ScoreId.Equals(s.ScoreId)).FirstOrDefault();
            if (ranked != null)
                return ranked;

            return new RankedScore(s);
        }

        public IEnumerable<RankedScore> Rank(IEnumerable<Score> scores)
        {
            foreach (var s in scores)
                yield return Rank(s);
        }
    }
}
