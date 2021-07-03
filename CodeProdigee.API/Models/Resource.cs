using CodeProdigee.API.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeProdigee.API.Models
{
    public class Resource : DomainModelBase
    {
        public string ResourceUrl { get; set; }

        public string Description { get; set; }

        public List<Post> Posts { get; set; }
    }
}
