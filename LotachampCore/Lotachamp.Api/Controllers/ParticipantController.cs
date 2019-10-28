using System;
using System.Collections.Generic;
using Lotachamp.Api.DataTransfer;
using Lotachamp.Application.Interfaces;
using Lotachamp.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lotachamp.Api.Controllers
{
    public class ParticipantController : BaseController
    {
        private readonly ParticipantService _manager;

        public ParticipantController(ILotachampContext ctx)
        {
            _manager = new ParticipantService(ctx);
        }

        [ProducesResponseType(typeof(ParticipantDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            if (id.Equals(Guid.Empty))
                return BadRequest("Empty guid.");

            var result = _manager.GetById(id);

            if (result != null)
                return Ok(result.AsDto());

            return NotFound($"Could not find participant with id: {id}.");
        }

        [ProducesResponseType(typeof(IEnumerable<ParticipantDto>), StatusCodes.Status200OK)]
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_manager.GetAll().AsDtos());
        }

        [ProducesResponseType(typeof(IEnumerable<ParticipantDto>), StatusCodes.Status200OK)]
        [HttpGet("{tourId}")]
        public IActionResult GetByTour(int tourId)
        {
            return Ok(_manager.GetByTour(tourId).AsDtos());
        }


    }
}