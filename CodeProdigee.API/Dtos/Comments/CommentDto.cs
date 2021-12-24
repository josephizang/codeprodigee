using CodeProdigee.API.Dtos.Commentators;
using CodeProdigee.API.Dtos.CommentReplies;
using CodeProdigee.API.Dtos.Reactions;
using System;
using System.Collections.Generic;

namespace CodeProdigee.API.Dtos.Comments
{
    public class CommentDto
    {
        public List<CommentReplyDto> Replies { get; set; }

        public CommentatorDto CommentAuthor { get; set; }

        public Guid PostID { get; set; }

        public Guid CommentAuthorID { get; set; }

        public string CommentBody { get; set; }

        public string Title { get; set; }

        public List<ReactionDto> Reactions { get; set; }

        public DateTimeOffset CreatedOn { get; set; }
    }
}
