﻿using System;
using System.Collections.Generic;
using System.Reflection;
using Lotachamp.Api.Mapping;
using Lotachamp.Api.ViewModels;
using Lotachamp.Application.Infrastructure;
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
        [ProducesResponseType(typeof(ScoreVM),StatusCodes.Status200OK)]
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
                    return Ok(result.AsViewModel());

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
        [ProducesResponseType(typeof(IEnumerable<ScoreVM>), StatusCodes.Status200OK)]
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
        /// Returns all scores for a specific tour
        /// </summary>
        /// <param name="tourId"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(IEnumerable<ScoreVM>), StatusCodes.Status200OK)]
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

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [HttpPost]
        public IActionResult Create([FromBody] ScoreFormVM dto) 
        {
            try
            {
                if (dto == null)
                    return BadRequest("DTO is null.");

                //var result = _dataSvc.CreateScore(dto);
                //if (result.Success != true) 
                //{
                //    ModelState.AddModelError()...
                //}

                return Created("", new ScoreVM());

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in class:{MethodBase.GetCurrentMethod().DeclaringType.Name}, method:{MethodBase.GetCurrentMethod().Name}");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}