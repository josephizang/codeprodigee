using CodeProdigee.API.Dtos.Resources;
using CodeProdigee.API.Dtos.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeProdigee.API.Dtos.Posts
{
    public class PostByTitleDto
    {
        public string PostTitle { get; set; }

        public DateTimeOffset PostDate { get; set; }

        public DateTimeOffset PublishDate { get; set; }

        public bool PublishPost { get; set; }

        public string PostSummary { get; set; }

        public string PostAuthor { get; set; }

        public Guid AuthorID { get; set; }

        public List<TagDto> Tags { get; set; } = new();

        public List<ResourceDto> Resources { get; set; } = new();

        public int NumberOfComments { get; set; }
        public Guid PostID { get; internal set; }
    }
}
