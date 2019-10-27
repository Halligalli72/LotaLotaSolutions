using System;
using System.Collections.Generic;
using Lotachamp.Api.DataTransfer;
using Lotachamp.Application.Interfaces;
using Lotachamp.Application.Managers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lotachamp.Api.Controllers
{
    public class TourController : BaseController
    {
        private readonly TourManager _manager;

        public TourController(ILotachampContext ctx)
        {
            _manager = new TourManager(ctx);
        }

        [ProducesResponseType(typeof(TourDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid id.");

            var result = _manager.GetById(id);

            if (result != null)
                return Ok(result.AsDto());

            return NotFound($"Could not find tour with id: {id}.");
        }

        [ProducesResponseType(typeof(IEnumerable<TourDto>), StatusCodes.Status200OK)]
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_manager.GetAll().AsDtos());
        }

        [ProducesResponseType(typeof(IEnumerable<TourDto>), StatusCodes.Status200OK)]
        [HttpGet]
        public IActionResult GetFuture()
        {
            return Ok(_manager.GetFuture().AsDtos());
        }

        [ProducesResponseType(typeof(IEnumerable<TourDto>), StatusCodes.Status200OK)]
        [HttpGet]
        public IActionResult GetPassed()
        {
            return Ok(_manager.GetPassed().AsDtos());
        }

        [ProducesResponseType(typeof(IEnumerable<TourDto>), StatusCodes.Status200OK)]
        [HttpGet]
        public IActionResult GetOngoing()
        {
            return Ok(_manager.GetOngoing().AsDtos());
        }
    }
}
