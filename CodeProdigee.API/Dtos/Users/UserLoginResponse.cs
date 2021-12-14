namespace CodeProdigee.API.Dtos.Users
{
    public class UserLoginResponse
    {
        public string Token { get; set; } = string.Empty;

        public bool LoginSuccessful { get; set; }

    }
}
