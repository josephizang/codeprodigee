using CodeProdigee.API.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeProdigee.API.Models
{
    public class Commentator : DomainModelBase
    {
        public List<Comment> CommentatorComments { get; set; }

        public string Email { get; set; }

        public string FullName { get; set; }

        public int ViolationCount { get; set; }
    }
}
