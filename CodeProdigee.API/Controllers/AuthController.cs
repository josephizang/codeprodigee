using CodeProdigee.API.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace CodeProdigee.API.Controllers
{
    [ApiController]
    [Route("identify")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationService _authService;

        public AuthController(IAuthenticationService authService)
        {
            _authService = authService;
        }
    }
}
