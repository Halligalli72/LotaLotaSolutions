using System;
using System.Collections.Generic;
using System.Reflection;
using Lotachamp.Api.Mapping;
using Lotachamp.Api.ViewModels;
using Lotachamp.Application.Infrastructure;
using Lotachamp.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lotachamp.Api.Controllers
{
    public class SportController : BaseController
    {
        private readonly ILoggerService _logger;
        private readonly ISportService _dataSvc;

        public SportController(ILoggerService logger, ISportService sportSvc)
        {
            _logger = logger;
            _dataSvc = sportSvc;
        }

        /// <summary>
        /// Gets a sport by id
        /// </summary>
        /// <param name="id">Sport key</param>
        /// <returns></returns>
        [ProducesResponseType(typeof(SportVM), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Invalid id.");

                var result = _dataSvc.GetById(id);

                if (result != null)
                    return Ok(result.AsViewModel());

                return NotFound($"Could not find sport with id: {id}.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in class:{MethodBase.GetCurrentMethod().DeclaringType.Name}, method:{MethodBase.GetCurrentMethod().Name}");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Returns all sports
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(IEnumerable<SportVM>), StatusCodes.Status200OK)]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_dataSvc.GetAll().AsViewModels());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in class:{MethodBase.GetCurrentMethod().DeclaringType.Name}, method:{MethodBase.GetCurrentMethod().Name}");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Gets all sports that belongs to a specific tour
        /// </summary>
        /// <param name="tourId">Tour key</param>
        /// <returns></returns>
        [ProducesResponseType(typeof(IEnumerable<SportVM>), StatusCodes.Status200OK)]
        [HttpGet("{tourId}")]
        public IActionResult GetByTour(int tourId)
        {
            try
            {
                return Ok(_dataSvc.GetByTour(tourId).AsViewModels());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in class:{MethodBase.GetCurrentMethod().DeclaringType.Name}, method:{MethodBase.GetCurrentMethod().Name}");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
