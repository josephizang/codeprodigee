using CodeProdigee.API.Abstractions;
using System.Collections.Generic;

namespace CodeProdigee.API.Models
{
    public class Resource : DomainModelBase
    {
        public string ResourceUrl { get; set; }

        public string Description { get; set; }

        public ResourceType PostResourceType { get; set; }

        public List<Post> Posts { get; set; } = new();

    }
}
