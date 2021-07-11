using CodeProdigee.API.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeProdigee.API.Models
{
    public class Blog : DomainModelBase
    {
        public string BlogAdminEmail { get; set; }

        public string AdminName { get; set; }

        public string BlogName { get; set; }

        public List<Post> Posts { get; set; } = new();
    }
}
