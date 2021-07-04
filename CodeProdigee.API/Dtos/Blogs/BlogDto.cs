using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeProdigee.API.Dtos.Blogs
{
    public class BlogDto
    {
        public Guid BlogID { get; set; }
        public string BlogAdminEmail { get; set; }

        public string AdminName { get; set; }

        public string BlogName { get; set; }

        public int PostsCount { get; set; }
    }
}
