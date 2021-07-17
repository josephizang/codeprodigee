using CodeProdigee.API.Command.Author;
using CodeProdigee.API.Dtos.Authors;
using CodeProdigee.API.Queries.Authors;
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
    [Route("api/authors")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthorsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<AuthorsController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces("application/json")]
        public async Task<ActionResult<List<AuthorsListDto>>> GetAuthorsList()
        {
            var result = await _mediator.Send(new AuthorsListQuery()).ConfigureAwait(false);
            return result;
        }

        // GET api/<AuthorsController>/5
        [HttpGet("{id}", Name = "GetAuthorByID")]
        public string Get(Guid id)
        {
            return "value";
        }

        // POST api/<AuthorsController>
        [HttpPost("createAuthor", Name = "CreateAuthor")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AuthorProcessedDto>> CreateAuthor([FromBody] AuthorCreateCommand command)
        {
            var result = await _mediator.Send(command).ConfigureAwait(false);
            return CreatedAtRoute("GetAuthorByID", result);
        }

        // PUT api/<AuthorsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AuthorsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
