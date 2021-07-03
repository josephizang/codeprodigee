using CodeProdigee.API.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeProdigee.API.Models
{
    public class Post : DomainModelBase
    {
        public string PostTitle { get; set; }

        public DateTimeOffset PostDate { get; set; }

        public string PostBody { get; set; }

        public DateTimeOffset PublishDate { get; set; }

        public bool PublishPost { get; set; }

        public Author PostAuthor { get; set; }

        public Guid AuthorID { get; set; }

        public List<Tag> Tags { get; set; }

        public List<Resource> Resources { get; set; }

        public List<Comment> Comments { get; set; }
    }
}
