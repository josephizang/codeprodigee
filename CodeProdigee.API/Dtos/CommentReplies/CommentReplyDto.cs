using CodeProdigee.API.Dtos.Reactions;
using System;
using System.Collections.Generic;

namespace CodeProdigee.API.Dtos.CommentReplies
{
    public class CommentReplyDto
    {
        public Guid CommentId { get; set; }

        public string ReplyBody { get; set; }

        public List<ReactionDto> Reactions { get; set; }
    }
}
