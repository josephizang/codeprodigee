using CodeProdigee.API.Dtos.Users;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CodeProdigee.API.Queries.Users
{
    public class UserLoginQuery : IRequest<UserLoginResponse>
    {
    }

    public class UserLoginQueryHandler : IRequestHandler<UserLoginQuery, UserLoginResponse>
    {
        public Task<UserLoginResponse> Handle(UserLoginQuery request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
