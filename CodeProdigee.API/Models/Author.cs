using CodeProdigee.API.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeProdigee.API.Models
{
    public class Author : DomainModelBase
    {
        public string AuthorName { get; set; }

        public string AuthorEmail { get; set; }

        public string AuthorTwitter { get; set; }

        public List<Post> AuthorPosts { get; set; }

        public List<Comment> AuthorComments { get; set; }

    }
}
