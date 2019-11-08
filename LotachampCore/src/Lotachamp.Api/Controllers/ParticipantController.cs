using System;
using System.Collections.Generic;
using System.Reflection;
using Lotachamp.Api.DataTransfer;
using Lotachamp.Application.Infrastructure;
using Lotachamp.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lotachamp.Api.Controllers
{
    public class ParticipantController : BaseController
    {
        private readonly ILoggerService _logger;
        private readonly IParticipantService _dataSvc;

        public ParticipantController(ILoggerService logger, IParticipantService participantSvc)
        {
            _logger = logger;
            _dataSvc = participantSvc;
        }

        /// <summary>
        /// Gets a participant by its id
        /// </summary>
        /// <param name="id">Participant key</param>
        /// <returns></returns>
        [ProducesResponseType(typeof(ParticipantDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                if (id.Equals(Guid.Empty))
                    return BadRequest("Invalid empty guid.");

                var result = _dataSvc.GetById(id);

                if (result != null)
                    return Ok(result.AsDto());

                return NotFound($"Could not find participant with id: {id}.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in class:{MethodBase.GetCurrentMethod().DeclaringType.Name}, method:{MethodBase.GetCurrentMethod().Name}");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Returns all participants
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(IEnumerable<ParticipantDto>), StatusCodes.Status200OK)]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_dataSvc.GetAll().AsDtos());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in class:{MethodBase.GetCurrentMethod().DeclaringType.Name}, method:{MethodBase.GetCurrentMethod().Name}");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Gets all participants that belongs to a specific tour
        /// </summary>
        /// <param name="tourId">Tour key</param>
        /// <returns></returns>
        [ProducesResponseType(typeof(IEnumerable<ParticipantDto>), StatusCodes.Status200OK)]
        [HttpGet("{tourId}")]
        public IActionResult GetByTour(int tourId)
        {
            try
            {
                return Ok(_dataSvc.GetByTour(tourId).AsDtos());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in class:{MethodBase.GetCurrentMethod().DeclaringType.Name}, method:{MethodBase.GetCurrentMethod().Name}");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


    }
}