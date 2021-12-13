using CodeProdigee.API.Abstractions;
using CodeProdigee.API.Dtos.Users;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CodeProdigee.API.Queries.Users
{
    public class UserLoginQuery : IRequest<AuthResponse>
    {
        public string Email { get; set; }

        public string Password { get; set; }

    }

    public class UserLoginQueryHandler : IRequestHandler<UserLoginQuery, AuthResponse>
    {
        private readonly IAuthenticationService _service;

        public UserLoginQueryHandler(IAuthenticationService service)
        {
            _service = service;
        }
        public async Task<AuthResponse> Handle(UserLoginQuery request, CancellationToken cancellationToken)
        {
            var response = await _service.Login(request).ConfigureAwait(false);
            if (response.RegistrationResponse.Error.Count > 0) return response;
            return response;

        }
    }
}
