using CodeProdigee.API.Abstractions;
using CodeProdigee.API.Command.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CodeProdigee.API.Controllers
{
    [ApiController]
    [Route("identify")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationService _authService;
        private readonly IMediator _mediator;

        public AuthController(IAuthenticationService authService, IMediator mediator)
        {
            _authService = authService;
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUsers([FromBody] RegisterUserCommand command)
        {
            var result = await _mediator.Send(command).ConfigureAwait(false);
            return string.IsNullOrEmpty(result.RegistrationResponse.Token) ? BadRequest(result.FailureResponse.Errors) : Ok(result.RegistrationResponse);
        }
    }
}
