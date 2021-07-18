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
        [HttpGet(Name = "GetAuthorsList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces("application/json")]
        public async Task<ActionResult<List<AuthorsListDto>>> GetAuthorsList()
        {
            var result = await _mediator.Send(new AuthorsListQuery()).ConfigureAwait(false);
            return result;
        }

        // GET api/<AuthorsController>/5
        [HttpGet("getAnAuthorById/{id:guid}", Name = "GetAuthorByID")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AuthorsListDto>> GetAuthorByID(Guid id)
        {
            var query = new GetOneAuthorQuery { AuthorID = id };
            try
            {
                var result = await _mediator.Send(query).ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("getAnAuthorByAny/{payload}", Name = "GetAuthorByAny")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AuthorsListDto>> GetAuthorByEmailTwitterOrGithub(string payload)
        {
            try
            {
                var query = new GetOneAuthorByVariousQuery { SearchParam = payload };
                var result = await _mediator.Send(query).ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // POST api/<AuthorsController>
        [HttpPost(Name = "CreateAuthor")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AuthorProcessedDto>> CreateAuthor([FromBody] AuthorCreateCommand command)
        {
            var result = await _mediator.Send(command).ConfigureAwait(false);
            return CreatedAtRoute("GetAuthorByID", result);
        }

        // PUT api/<AuthorsController>/5
        [HttpPut("updateAuthor/{id:guid}", Name = "UpdateAuthor")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AuthorProcessedDto>> UpdateAuthor(Guid id,[FromBody] AuthorUpdateCommand command)
        {
            try
            {
                var result = await _mediator.Send(command).ConfigureAwait(false);
                return CreatedAtRoute("GetAuthorByID", result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        // DELETE api/<AuthorsController>/5
        [HttpDelete("deleteAuthor/{id:guid}", Name = "DeleteAuthor")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Delete([FromBody]AuthorDeleteCommand command)
        {
            try
            {
                var result = await _mediator.Send(command).ConfigureAwait(false);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { ErrorMessage = ex.Message });
            }
        }
    }
}
