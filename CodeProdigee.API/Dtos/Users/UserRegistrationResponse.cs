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
        public List<string> Errors { get; set; } = new List<string>();
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
            SuccessResponse = new();
            FailureResponse = new();
            LoginResponse = new();
            RegistrationResponse = new();
        }
        public AuthSuccessResponse SuccessResponse { get; set; }

        public AuthFailureResponse FailureResponse { get; set; }

        public UserLoginResponse LoginResponse { get; set; }

        public UserRegistrationResponse RegistrationResponse { get; set; }

    }
}
