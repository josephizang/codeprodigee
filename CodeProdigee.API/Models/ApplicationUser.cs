using CodeProdigee.API.Abstractions;
using System.Collections.Generic;

namespace CodeProdigee.API.Models
{
    public class ApplicationUser : BaseIdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string IpAddress { get; set; }

        public string AvatarImageUrl { get; set; }

        public string AuthorTwitter { get; set; }

        public string AuthorGithub { get; set; }

        public string Bio { get; set; }

        public List<Post> AuthorPosts { get; set; }

        public List<Comment> AuthorComments { get; set; }
    }
}
