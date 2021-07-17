using CodeProdigee.API.Command.Post;
using CodeProdigee.API.Dtos.Posts;
using CodeProdigee.API.EventNotifications.Posts;
using CodeProdigee.API.Queries.Posts;
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
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PostsController(IMediator mediator)
        {
            _mediator = mediator;
        }


        // Look into enabling caching or working with redis as this will definitely be a hot path
        // GET: api/<PostsController>
        [HttpGet("getallposts", Name = "GetAllPosts")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<PostDto>>> GetAllPosts()
        {
            try
            {
                var result = await _mediator.Send(new PostIndexQuery()).ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        // GET api/<PostsController>/5
        [HttpGet("getpostbyid/{id}", Name = "GetPostsById")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PostDto>> GetPostsById(Guid id)
        {
            try
            {
                var result = await _mediator.Send(new GetOnePostQuery()).ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { ErrorMessage = ex.Message });
            }
        }

        [HttpGet("getpostbytitle/{title:string}", Name = "GetPostsByTitle")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PostDto>> GetPostsByTitle(string title)
        {
            try
            {
                var result = await _mediator.Send(new GetOnePostQuery()).ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { ErrorMessage = ex.Message });
            }
        }

        // POST api/<PostsController>
        [HttpPost("createPost", Name = "CreatePost")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PostProcessedDto>> CreatePost([FromBody] PostCreateCommand command)
        {
            try
            {
                var result = await _mediator.Send(command).ConfigureAwait(false);
                return Created("api/posts", result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        // PUT api/<PostsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<PostProcessedDto>> Put(Guid id, [FromBody] PostUpdateCommand command)
        {
            try
            {
                command.PostID = id;
                var result = await _mediator.Send(command).ConfigureAwait(false);
                return result;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<PostsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
