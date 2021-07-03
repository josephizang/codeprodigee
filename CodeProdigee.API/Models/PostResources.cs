﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeProdigee.API.Models
{
    public class PostResources
    {
        public Post Post { get; set; }

        public Guid PostID { get; set; }

        public Resource Resource { get; set; }

        public Guid ResourceID { get; set; }
    }
}