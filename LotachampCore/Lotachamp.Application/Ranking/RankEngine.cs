using Lotachamp.Application.BusinessObjects;
using Lotachamp.Application.Interfaces;
using Lotachamp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lotachamp.Application.Ranking
{
    public interface IRankEngine
    {
        IEnumerable<ScoreBO> Rank(IEnumerable<Score> scores);
        ScoreBO Rank(Score s);
    }

    public class RankEngine : IRankEngine
    {
        private readonly ILotachampContext _ctx;

        private IList<ScoreBO> _rankedScores = new List<ScoreBO>();

        private RankEngine() { }

        public RankEngine(ILotachampContext ctx)
        {
            _ctx = ctx;
        }

        public ScoreBO Rank(Score s)
        {
            ScoreBO ranked = _rankedScores.Where(o => o.ScoreId.Equals(s.ScoreId)).FirstOrDefault();
            if (ranked != null)
                return ranked;

            return new ScoreBO(s);
        }

        public IEnumerable<ScoreBO> Rank(IEnumerable<Score> scores)
        {
            foreach (var s in scores)
                yield return Rank(s);
        }
    }
}
