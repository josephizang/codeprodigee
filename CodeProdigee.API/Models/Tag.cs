using CodeProdigee.API.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeProdigee.API.Models
{
    public class Tag : DomainModelBase
    {
        public string TagName { get; set; }

        public List<Post> Posts { get; set; }

        public List<PostTags> PostTags { get; set; }

    }
}
