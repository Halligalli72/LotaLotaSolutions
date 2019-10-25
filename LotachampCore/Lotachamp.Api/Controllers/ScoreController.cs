using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lotachamp.Api.DataTransfer;
using Lotachamp.Application.Interfaces;
using Lotachamp.Application.Managers;
using Lotachamp.Persistance;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lotachamp.Api.Controllers
{
    public class ScoreController : BaseController
    {
        private readonly ScoreManager _scoreMgr;

        public ScoreController(ILotachampContext ctx) 
        {
            _scoreMgr = new ScoreManager(ctx);
        }

        /// <summary>
        /// Gets a score by its id
        /// </summary>
        /// <param name="scoreId">Id</param>
        /// <returns></returns>
        [ProducesResponseType(typeof(ScoreDto),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [HttpGet("{scoreId}")]
        public IActionResult GetById(Guid scoreId) 
        {
            if (scoreId.Equals(Guid.Empty))
                return BadRequest("Empty guid.");

            var dummyGuid = Guid.Parse("A754CFFB-A091-4B39-8571-576BF532858E");
            if (scoreId == dummyGuid)
            {
                var result = new ScoreDto();
                return Ok(result);
            }

            return NotFound($"Could not find score with id: {scoreId}.");
        }


        [ProducesResponseType(typeof(IEnumerable<ScoreDto>), StatusCodes.Status200OK)]
        [HttpGet]
        public IActionResult All() 
        {
            var result = _scoreMgr.GetAll();

            return Ok(result);

        }

    }
}