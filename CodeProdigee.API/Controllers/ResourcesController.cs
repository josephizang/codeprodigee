using CodeProdigee.API.Dtos.Resources;
using CodeProdigee.API.Queries.Resources;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CodeProdigee.API.Controllers
{
    [Route("api/resources")]
    [ApiController]
    public class ResourcesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ResourcesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<ResourcesController>
        [HttpGet(Name = "GetAllResources")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<ResourceListDto>>> GetAllResources()
        {
            try
            {
                var result = await _mediator.Send(new GetResourcesQuery()).ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }

        // GET api/<ResourcesController>/5
        [HttpGet("getAResource/{id:guid}", Name = "GetOneResource")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ResourceDto>> GetAResource(Guid id)
        {
            try
            {
                var query = new GetAResourceQuery { ResourceID = id };
                var result = await _mediator.Send(query).ConfigureAwait(false);

                return result is null ? NotFound() : Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }

        // POST api/<ResourcesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ResourcesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ResourcesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
