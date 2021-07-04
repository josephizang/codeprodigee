using CodeProdigee.API.Dtos.Commentators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeProdigee.API.Dtos.Comments
{
    public class CommentDto
    {
        public List<CommentDto> Replies { get; set; }

        public CommentatorDto CommentAuthor { get; set; }

        public Guid PostID { get; set; }

        public Guid CommentAuthorID { get; set; }

        public string CommentBody { get; set; }

        public string Title { get; set; }

        public List<bool> Likes { get; set; }

        public List<bool> DisLikes { get; set; }
    }
}
