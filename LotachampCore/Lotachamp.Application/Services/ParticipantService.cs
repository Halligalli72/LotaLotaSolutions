using Lotachamp.Application.Interfaces;
using Lotachamp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lotachamp.Application.Services
{
    public class ParticipantService
    {
        private readonly ILotachampContext _ctx;

        public ParticipantService(ILotachampContext ctx)
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
