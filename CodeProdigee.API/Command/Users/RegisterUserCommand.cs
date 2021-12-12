using CodeProdigee.API.Abstractions;
using CodeProdigee.API.Dtos.Users;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CodeProdigee.API.Command.Users
{
    public class RegisterUserCommand : IRequest<AuthResponse>
    {
        public string Email { get; set; }

        public string Password { get; set; }

    }

    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, AuthResponse>
    {
        private readonly IAuthenticationService _auth;

        public RegisterUserCommandHandler(IAuthenticationService authService)
        {
            _auth = authService;
        }
        public async Task<AuthResponse> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var authResponse = new AuthResponse();
            var response = await _auth.RegisterUser(request).ConfigureAwait(false);

            if (!response.Success)
            {
                authResponse.FailureResponse.Errors = response.Error;
                return authResponse;
            }

            authResponse.RegistrationResponse.Token = response.Token;
            return authResponse;
        }
    }
}
