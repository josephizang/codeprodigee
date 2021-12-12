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
}
