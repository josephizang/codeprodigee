using CodeProdigee.API.Dtos.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeProdigee.API.Dtos.Posts
{
    public class PostCreateDto
    {
        public string PostTitle { get; set; }

        public string PostBody { get; set; }

        public string PostTags { get; set; }

        public bool Publish { get; set; }

        public string AuthorEmail { get; set; }

        public string AuthorName { get; set; }

        public List<ResourceDto> PostResources { get; set; }
    }
}
