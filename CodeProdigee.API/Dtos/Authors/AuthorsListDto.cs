using System;

namespace CodeProdigee.API.Dtos.Authors
{
    public class AuthorsListDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTimeOffset DateJoined { get; set; }

        public string AuthorEmail { get; set; }

        public string AuthorTwitter { get; set; }

        public string AuthorGithub { get; set; }

        public string Bio { get; set; }

        public int AuthorPostsCount { get; set; }

        public Guid AuthorID { get; set; }

    }
}
