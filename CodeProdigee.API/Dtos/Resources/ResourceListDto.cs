using CodeProdigee.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeProdigee.API.Dtos.Resources
{
    public class ResourceListDto
    {
        public string ResourceUrl { get; set; }

        public ResourceType Type { get; set; }

        public Guid ResourceID { get; set; }

        public DateTimeOffset DateCreated { get; set; }

        public int NumberOfUses { get; set; }
    }
}
