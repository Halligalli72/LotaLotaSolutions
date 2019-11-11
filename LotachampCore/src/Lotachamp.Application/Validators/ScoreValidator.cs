using System;
using System.Collections.Generic;
using System.Text;
using Lotachamp.Application.Infrastructure;
using Lotachamp.Domain.Entities;

namespace Lotachamp.Application.Validators
{
    public class ScoreValidator : IEntityValidator<Score>
    {
        private ILotachampContext _ctx = null;
        private Score _entity = null;

        public ScoreValidator(ILotachampContext context)
        {
            _ctx = context;
        }

        public IValidationResult Result { get; private set; } = null;


        public IValidationResult ValidateForCreate(Score entity)
        {
            const int historyRegistrationLimit = 7;
            DateTime breakDate = DateTime.Now.AddDays(-historyRegistrationLimit);

            _entity = entity;

            Result = new ValidationResult();
            if (_entity != null)
            {
                //Check for empty guids
                if (_entity.SportId.Equals(0))
                    Result.Errors.Add(new ValidationError { Property = "SportId", ErrorMessage = "Cannot be empty" });
                if (_entity.ParticipantId.Equals(Guid.Empty))
                    Result.Errors.Add(new ValidationError { Property = "ParticipantId", ErrorMessage = "Cannot be empty" });
                //Check for existance
                var sport = _ctx.Sports.Find(_entity.SportId);
                if (sport == null)
                    Result.Errors.Add(new ValidationError { Property = "SportId", ErrorMessage = $"Value does not exist: {_entity.SportId}" });
                var participant = _ctx.Participants.Find(_entity.ParticipantId);
                if (participant == null)
                    Result.Errors.Add(new ValidationError { Property = "ParticipantId", ErrorMessage = $"Value does not exist: {_entity.ParticipantId}" });
                //Logic checks
                if (sport != null && participant != null)
                    if (sport.TourId != participant.TourId)
                        Result.Errors.Add(new ValidationError { Property = "", ErrorMessage = $"Participant with id:{_entity.ParticipantId} does not belong to same tour as sport event with id:{_entity.SportId}" });
                if (sport != null)
                {
                    //check score date
                    var tour = _ctx.Tours.Find(sport.TourId);
                    if (_entity.ScoreDate < tour.StartDate)
                        Result.Errors.Add(new ValidationError { Property = "ScoreDate", ErrorMessage = "Score date is earlier than tour start date" });
                    if (_entity.ScoreDate > tour.EndDate)
                        Result.Errors.Add(new ValidationError { Property = "ScoreDate", ErrorMessage = "Score date is later than tour end date" });
                    if (entity.ScoreDate > DateTime.Now)
                        Result.Errors.Add(new ValidationError { Property = "ScoreDate", ErrorMessage = "Score date is in the future, it is not allowed" });
                    if (entity.ScoreDate < breakDate)
                        Result.Errors.Add(new ValidationError { Property = "ScoreDate", ErrorMessage = $"You are not allowed to register scores older than { historyRegistrationLimit } days" });
                }
            }
            else
            {
                Result.Errors.Add(new ValidationError { Property = "", ErrorMessage = "No validation possible.Target is null.Target type: Score" });
            }
            return Result;
        }

        public IValidationResult ValidateForUpdate(Score entity)
        {
            throw new NotImplementedException();
        }
    }
}
