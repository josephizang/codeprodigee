using CodeProdigee.API.Abstractions;
using CodeProdigee.API.Command.Users;
using CodeProdigee.API.Core;
using CodeProdigee.API.Dtos.Users;
using CodeProdigee.API.Models;
using CodeProdigee.API.Queries.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CodeProdigee.API.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly JwtSettings _jwtSettings;
        private IOptions<JwtSettings> _jwtOptions;
        private UserRegistrationResponse response = new UserRegistrationResponse();

        public AuthenticationService(UserManager<ApplicationUser> userManager, JwtSettings jwtSettings)
        {
            _userManager = userManager;
            _jwtSettings = jwtSettings;
        }


        public Task<UserLoginResponse> Login(UserLoginQuery command)
        {
            throw new System.NotImplementedException();
        }

        public async Task<UserRegistrationResponse> RegisterUser(RegisterUserCommand command)
        {
            var userExists = await _userManager.FindByEmailAsync(command.Email).ConfigureAwait(false);
            if (userExists is not null)
            {
                response.Error.Add("User with this email already exists!");
                return response;
            }
            var newUser = new ApplicationUser
            {
                Email = command.Email,
                UserName = command.Email
            };
            var newUserCreated = await _userManager.CreateAsync(newUser, command.Password);

            if (!newUserCreated.Succeeded)
            {
                response.Error = newUserCreated.Errors.Select(x => x.Description).ToList();
                return response;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, newUser.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, newUser.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, newUser.Id),
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            response.Success = true;
            response.Token = tokenHandler.WriteToken(token);
            return response;
        }
    }
}
