using System;
using System.Collections.Generic;
using System.Reflection;
using Lotachamp.Api.DataTransfer;
using Lotachamp.Application.Interfaces;
using Lotachamp.Application.Ranking;
using Lotachamp.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lotachamp.Api.Controllers
{
    public class ScoreController : BaseController
    {
        private readonly ILoggerService _logger;
        private readonly IScoreService _dataSvc;

        public ScoreController(ILoggerService logger, IScoreService scoreSvc) 
        {
            _logger = logger;
            _dataSvc = scoreSvc;
        }

        /// <summary>
        /// Gets a score by its id
        /// </summary>
        /// <param name="id">Score key</param>
        /// <returns></returns>
        [ProducesResponseType(typeof(ScoreDto),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [HttpGet("{id}")]
        public IActionResult Get(Guid id) 
        {
            try
            {
                if (id.Equals(Guid.Empty))
                    return BadRequest("Empty guid.");

                var result = _dataSvc.GetById(id);
                if (result != null)
                    return Ok(result.AsDto());

                return NotFound($"Could not find score with id: {id}.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in class:{MethodBase.GetCurrentMethod().DeclaringType.Name}, method:{MethodBase.GetCurrentMethod().Name}");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Returns all scores
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(IEnumerable<ScoreDto>), StatusCodes.Status200OK)]
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
        /// Returns all scores for a specific tour
        /// </summary>
        /// <param name="tourId"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(IEnumerable<ScoreDto>), StatusCodes.Status200OK)]
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