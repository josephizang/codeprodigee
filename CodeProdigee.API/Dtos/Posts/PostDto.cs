using CodeProdigee.API.Dtos.Comments;
using CodeProdigee.API.Dtos.Resources;
using CodeProdigee.API.Dtos.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeProdigee.API.Dtos.Posts
{
    public class PostDto
    {
        public string PostTitle { get; set; }

        public DateTime PostDate { get; set; }

        public DateTime PublishDate { get; set; }

        public bool PublishPost { get; set; }

        public string Postbody { get; set; }

        public string PostAuthor { get; set; }

        public Guid AuthorID { get; set; }

        public List<TagDto> Tags { get; set; } = new();

        public List<ResourceDto> Resources { get; set; } = new();

        public List<CommentDto> Comments { get; set; } = new();
        public Guid PostID { get; internal set; }
    }
}
