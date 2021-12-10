using CodeProdigee.API.Abstractions;
using CodeProdigee.API.Command.Users;
using CodeProdigee.API.Dtos.Users;
using CodeProdigee.API.Queries.Users;
using System.Threading.Tasks;

namespace CodeProdigee.API
{
    public class AuthenticationService : IAuthenticationService
    {
        public AuthenticationService()
        {

        }

        public Task<UserLoginResponse> Login(UserLoginQuery command)
        {
            throw new System.NotImplementedException();
        }

        public Task<UserRegistrationResponse> RegisterUser(RegisterUserCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}
