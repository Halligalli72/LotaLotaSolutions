using System;
using System.Collections.Generic;
using Lotachamp.Api.DataTransfer;
using Lotachamp.Application.Interfaces;
using Lotachamp.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lotachamp.Api.Controllers
{
    public class TourController : BaseController
    {
        private readonly TourService _dataSvc;

        public TourController(ILotachampContext ctx)
        {
            _dataSvc = new TourService(ctx);
        }

        [ProducesResponseType(typeof(TourDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid id.");

            var result = _dataSvc.GetById(id);

            if (result != null)
                return Ok(result.AsDto());

            return NotFound($"Could not find tour with id: {id}.");
        }

        [ProducesResponseType(typeof(IEnumerable<TourDto>), StatusCodes.Status200OK)]
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_dataSvc.GetAll().AsDtos());
        }

        [ProducesResponseType(typeof(IEnumerable<TourDto>), StatusCodes.Status200OK)]
        [HttpGet]
        public IActionResult GetPassed()
        {
            return Ok(_dataSvc.GetPassed().AsDtos());
        }

        [ProducesResponseType(typeof(IEnumerable<TourDto>), StatusCodes.Status200OK)]
        [HttpGet]
        public IActionResult GetOngoing()
        {
            return Ok(_dataSvc.GetOngoing().AsDtos());
        }

        [ProducesResponseType(typeof(IEnumerable<TourDto>), StatusCodes.Status200OK)]
        [HttpGet]
        public IActionResult GetFuture()
        {
            return Ok(_dataSvc.GetFuture().AsDtos());
        }
    }
}
