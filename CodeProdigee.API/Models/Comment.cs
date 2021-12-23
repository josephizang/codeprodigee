using CodeProdigee.API.Abstractions;
using System;
using System.Collections.Generic;

namespace CodeProdigee.API.Models
{
    public class Comment : DomainModelBase
    {
        public List<Comment> Replies { get; set; } = new();

        public Commentator CommentAuthor { get; set; }

        public Post Post { get; set; }

        public Guid PostID { get; set; }

        public Guid CommentAuthorID { get; set; }

        public string CommentBody { get; set; }

        public string Title { get; set; }

        public List<bool> Likes { get; set; } = new();

        public List<bool> DisLikes { get; set; } = new();



    }
}
