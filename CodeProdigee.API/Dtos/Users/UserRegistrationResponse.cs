namespace CodeProdigee.API.Dtos.Users
{
    public class UserRegistrationResponse
    {
        public string Token { get; set; }

        public bool Success { get; set; }

        public string Error { get; set; }
    }
}
