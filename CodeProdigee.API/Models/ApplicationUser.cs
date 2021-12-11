using Microsoft.AspNetCore.Identity;

namespace CodeProdigee.API.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string IpAddress { get; set; }

        public string AvatarImageUrl { get; set; }

    }
}
