using CodeProdigee.API.Abstractions;
using System.Collections.Generic;

namespace CodeProdigee.API.Models
{
    public class Tag : DomainModelBase
    {
        public string TagName { get; set; }

        public List<Post> Posts { get; set; } = new();

    }
}
