using Lotachamp.Application.Infrastructure;
using Lotachamp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lotachamp.Application.Services
{
    public interface IParticipantService
    {
        IEnumerable<Participant> GetAll();
        Participant GetById(Guid scoreId);
        IEnumerable<Participant> GetByTour(int tourId);
    }

    public class ParticipantService : IParticipantService
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

        public Participant GetById(Guid participantId)
        {
            return _ctx.Participants.Where(o => o.ParticipantId.Equals(participantId)).FirstOrDefault();
        }
        public IEnumerable<Participant> GetByTour(int tourId)
        {
            return _ctx.Participants.Where(o => o.TourId.Equals(tourId)).AsEnumerable();
        }

    }
}
