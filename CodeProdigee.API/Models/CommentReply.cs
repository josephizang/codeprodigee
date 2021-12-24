using CodeProdigee.API.Abstractions;
using System;
using System.Collections.Generic;

namespace CodeProdigee.API.Models
{
    public class CommentReply : DomainModelBase
    {
        public Guid CommentId { get; set; }

        public Comment Comment { get; set; }

        public string ReplyBody { get; set; }

        public List<Reaction> Reactions { get; set; }
    }
}
