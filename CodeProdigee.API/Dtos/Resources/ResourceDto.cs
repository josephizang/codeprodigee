using CodeProdigee.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeProdigee.API.Dtos.Resources
{
    public class ResourceDto
    {
        public string ResourceUrl { get; set; }

        public ResourceType Type { get; set; }
    }
}
