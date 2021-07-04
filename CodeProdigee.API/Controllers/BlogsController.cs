using CodeProdigee.API.Command.Blog;
using CodeProdigee.API.Dtos.Blogs;
using CodeProdigee.API.Queries.Blogs;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CodeProdigee.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BlogsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<BlogsController>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<BlogDto>>> Get()
        {
            var result = await _mediator.Send(new BlogIndexQuery()).ConfigureAwait(false);
            return Ok(result);
        }

        // GET api/<BlogsController>/5
        [HttpGet("{id}", Name = "GetBlogsById")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BlogDto>> Get(Guid id)
        {
            var result = await _mediator.Send(new BlogGetByIdQuery()).ConfigureAwait(false);

            if (result is null)
                return BadRequest(new { Message = $"The blog with Id {id} could not be found!" });
            return Ok(result);
        }

        // POST api/<BlogsController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BlogDto>> Post([FromBody] BlogCreationCommand command)
        {
            try
            {
                var result = await _mediator.Send(command).ConfigureAwait(false);
                return CreatedAtRoute("GetBlogsById", new { id = result.BlogID }, result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        // PUT api/<BlogsController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BlogDto>> Put(Guid id, [FromBody] BlogUpdateCommand command)
        {
            try
            {
                var result = await _mediator.Send(command).ConfigureAwait(false);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        // DELETE api/<BlogsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
