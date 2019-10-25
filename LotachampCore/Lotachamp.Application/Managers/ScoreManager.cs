using Lotachamp.Application.Interfaces;
using Lotachamp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lotachamp.Application.Managers
{
    public class ScoreManager
    {
        private readonly ILotachampContext _ctx;
        public ScoreManager(ILotachampContext ctx) 
        {
            _ctx = ctx;
        }

        public IEnumerable<Score> GetAll() 
        {
            return _ctx.Scores.AsEnumerable();
        }

        public Score GetById(Guid scoreId) 
        {
            return _ctx.Scores.Where(s => s.ScoreId.Equals(scoreId)).FirstOrDefault();
        }
    }
}
