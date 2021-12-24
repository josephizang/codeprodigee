using System;

namespace CodeProdigee.API.Dtos.Reactions
{
    public class ReactionDto
    {
        public bool Like { get; set; }

        public bool DisLike { get; set; }

        public string Email { get; set; }

        public DateTimeOffset CreatedOn { get; set; }
    }
}
