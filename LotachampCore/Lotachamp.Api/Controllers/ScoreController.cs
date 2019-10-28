using System;
using System.Collections.Generic;
using Lotachamp.Api.DataTransfer;
using Lotachamp.Application.Interfaces;
using Lotachamp.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lotachamp.Api.Controllers
{
    public class ScoreController : BaseController
    {
        private readonly ScoreService _dataSvc;

        public ScoreController(ILotachampContext ctx) 
        {
            _dataSvc = new ScoreService(ctx);
        }

        /// <summary>
        /// Gets a score by its id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        [ProducesResponseType(typeof(ScoreDto),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [HttpGet("{id}")]
        public IActionResult Get(Guid id) 
        {
            if (id.Equals(Guid.Empty))
                return BadRequest("Empty guid.");

            var result = _dataSvc.GetById(id);
            if (result != null)
                return Ok(result.AsDto());

            return NotFound($"Could not find score with id: {id}.");
        }


        [ProducesResponseType(typeof(IEnumerable<ScoreDto>), StatusCodes.Status200OK)]
        [HttpGet]
        public IActionResult GetAll() 
        {
            return Ok(_dataSvc.GetAll().AsDtos());
        }

    }
}