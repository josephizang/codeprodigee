using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeProdigee.API.Models
{
    public class PostTags
    {
        public Tag Tag { get; set; }

        public Guid TagID { get; set; }

        public Post Post { get; set; }

        public Guid PostID { get; set; }

        public DateTimeOffset PublishDate { get; set; }
    }
}
