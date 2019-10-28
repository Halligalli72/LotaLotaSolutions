using System;
using System.Collections.Generic;
using Lotachamp.Api.DataTransfer;
using Lotachamp.Application.Interfaces;
using Lotachamp.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lotachamp.Api.Controllers
{
    public class SportController : BaseController
    {

        private readonly SportService _dataSvc;

        public SportController(ILotachampContext ctx)
        {
            _dataSvc = new SportService(ctx);
        }

        [ProducesResponseType(typeof(SportDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id <= 0 )
                return BadRequest("Invalid id.");

            var result = _dataSvc.GetById(id);

            if (result != null)
                return Ok(result.AsDto());

            return NotFound($"Could not find sport with id: {id}.");
        }

        [ProducesResponseType(typeof(IEnumerable<SportDto>), StatusCodes.Status200OK)]
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_dataSvc.GetAll().AsDtos());
        }

        [ProducesResponseType(typeof(IEnumerable<SportDto>), StatusCodes.Status200OK)]
        [HttpGet("{tourId}")]
        public IActionResult GetByTour(int tourId)
        {
            return Ok(_dataSvc.GetByTour(tourId).AsDtos());
        }

    }
}
