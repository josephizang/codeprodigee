using CodeProdigee.API.Abstractions;
using CodeProdigee.API.Dtos.Users;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CodeProdigee.API.Command.Users
{
    public class RegisterUserCommand : IRequest<UserRegistrationResponse>
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string FullName { get; set; }
    }

    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, UserRegistrationResponse>
    {
        private readonly IAuthenticationService _auth;

        public RegisterUserCommandHandler(IAuthenticationService authService)
        {
            _auth = authService;
        }
        public Task<UserRegistrationResponse> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
