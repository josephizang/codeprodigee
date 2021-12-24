using CodeProdigee.API.Abstractions;
using System.Collections.Generic;

namespace CodeProdigee.API.Models
{
    public class Commentator : DomainModelBase
    {
        public List<Comment> CommentatorComments { get; set; } = new();

        public List<CommentReply> CommentReplies { get; set; } = new();

        public List<Reaction> Reactions { get; set; } = new();

        public string Email { get; set; }

        public string FullName { get; set; }

        public int ViolationCount { get; set; }

        public string IpAddress { get; set; }
    }
}
