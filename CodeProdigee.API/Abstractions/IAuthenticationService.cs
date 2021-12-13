﻿using CodeProdigee.API.Command.Users;
using CodeProdigee.API.Dtos.Users;
using CodeProdigee.API.Queries.Users;
using System.Threading.Tasks;

namespace CodeProdigee.API.Abstractions
{
    public interface IAuthenticationService
    {
        Task<AuthResponse> RegisterUser(RegisterUserCommand command);

        Task<AuthResponse> Login(UserLoginQuery command);
    }
}
