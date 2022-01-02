using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeProdigee.API.Abstractions
{
    public interface IDomainModel
    {
        Guid ID { get; set; }

        DateTime CreatedAt { get; set; }

        DateTime UpdatedAt { get; set; }

        string UpdatedBy { get; set; }

        string CreatedBy { get; set; }

    }
}
