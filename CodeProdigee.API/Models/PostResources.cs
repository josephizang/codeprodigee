using CodeProdigee.API.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeProdigee.API.Models
{
    public class PostResources : DomainModelBase
    {
        public Post Post { get; set; }

        public Guid PostID { get; set; }

        public Resource Resource { get; set; }

        public Guid ResourceID { get; set; }

        public DateTimeOffset PublishDate { get; set; }
    }
}
