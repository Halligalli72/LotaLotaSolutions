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
    public class TournamentController : BaseController
    {
        private readonly ILoggerService _logger;
        private readonly ITournamentService _dataSvc;

        public TournamentController(ILoggerService logger, ITournamentService tourSvc)
        {
            _logger = logger;
            _dataSvc = tourSvc;
        }

        /// <summary>
        /// Gets a tour by its key
        /// </summary>
        /// <param name="id">Tour key</param>
        /// <returns></returns>
        [ProducesResponseType(typeof(TournamentVM), StatusCodes.Status200OK)]
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

                return NotFound($"Could not find tour with id: {id}.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in class:{MethodBase.GetCurrentMethod().DeclaringType.Name}, method:{MethodBase.GetCurrentMethod().Name}");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Returns all tours
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(IEnumerable<TournamentVM>), StatusCodes.Status200OK)]
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
        /// Returns all ended tours 
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(IEnumerable<TournamentVM>), StatusCodes.Status200OK)]
        [HttpGet]
        public IActionResult GetEnded()
        {
            try
            {
                return Ok(_dataSvc.GetEnded().AsViewModels());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in class:{MethodBase.GetCurrentMethod().DeclaringType.Name}, method:{MethodBase.GetCurrentMethod().Name}");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Returns all tours that are ongoing
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(IEnumerable<TournamentVM>), StatusCodes.Status200OK)]
        [HttpGet]
        public IActionResult GetOngoing()
        {
            try
            {
                return Ok(_dataSvc.GetOngoing().AsViewModels());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in class:{MethodBase.GetCurrentMethod().DeclaringType.Name}, method:{MethodBase.GetCurrentMethod().Name}");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Get ongoing toure for a specific user
        /// </summary>
        /// <param name="appUserId">Application user id</param>
        /// <returns></returns>
        [ProducesResponseType(typeof(IEnumerable<TournamentVM>), StatusCodes.Status200OK)]
        [HttpGet("{appUserId}")]
        public IActionResult GetOngoing(int appUserId)
        {
            try
            {
                return Ok(_dataSvc.GetOngoingForUser(appUserId).AsViewModels());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in class:{MethodBase.GetCurrentMethod().DeclaringType.Name}, method:{MethodBase.GetCurrentMethod().Name}");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Returns all tours that are not started yet
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(IEnumerable<TournamentVM>), StatusCodes.Status200OK)]
        [HttpGet]
        public IActionResult GetFuture()
        {
            try
            {
                return Ok(_dataSvc.GetFuture().AsViewModels());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in class:{MethodBase.GetCurrentMethod().DeclaringType.Name}, method:{MethodBase.GetCurrentMethod().Name}");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
