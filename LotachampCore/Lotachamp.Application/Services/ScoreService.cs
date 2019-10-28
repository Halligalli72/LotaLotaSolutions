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

        public Score GetById(Guid scoreId) 
        {
            return _ctx.Scores.Where(o => o.ScoreId.Equals(scoreId)).FirstOrDefault();
        }
    }
}
