using System.Collections.Generic;

namespace CodeProdigee.API.Dtos.Users
{
    public class UserRegistrationResponse
    {
        public UserRegistrationResponse()
        {
            Error = new();
        }
        public string Token { get; set; }

        public bool Success { get; set; }

        public List<string> Error { get; set; }
    }

    public class AuthFailureResponse
    {
        public IEnumerable<string> Errors { get; set; } = new List<string>();
    }

    public class AuthSuccessResponse
    {
        public string Token { get; set; }
    }

    public class LoginSuccessResponse
    {
        public string LoginPayload { get; set; }
    }

    public class AuthResponse
    {
        public AuthResponse()
        {
            RegistrationResponse = new();
            FailureResponse = new();
            LoginResponse = new();
        }
        public AuthSuccessResponse RegistrationResponse { get; set; }

        public AuthFailureResponse FailureResponse { get; set; }

        public UserLoginResponse LoginResponse { get; set; }
    }
}
