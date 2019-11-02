using System;
using System.Collections.Generic;
using System.Reflection;
using Lotachamp.Api.DataTransfer;
using Lotachamp.Application.Interfaces;
using Lotachamp.Application.Services;
using Lotachamp.Infrastructure.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lotachamp.Api.Controllers
{
    public class ScoreController : BaseController
    {
        private readonly ILoggingService _logger;
        private readonly ScoreService _dataSvc;

        public ScoreController(ILoggingService logger, ILotachampContext ctx) 
        {
            _logger = logger;
            _dataSvc = new ScoreService(ctx);
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

    }
}