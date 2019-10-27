using Lotachamp.Application.Interfaces;
using Lotachamp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lotachamp.Application.Managers
{
    public class ParticipantManager
    {
        private readonly ILotachampContext _ctx;

        public ParticipantManager(ILotachampContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Participant> GetAll()
        {
            return _ctx.Participants.AsEnumerable();
        }

        public Participant GetById(Guid scoreId)
        {
            return _ctx.Participants.Where(o => o.ParticipantId.Equals(scoreId)).FirstOrDefault();
        }
        public IEnumerable<Participant> GetByTour(int tourId)
        {
            return _ctx.Participants.Where(o => o.TourId.Equals(tourId)).AsEnumerable();
        }

    }
}
