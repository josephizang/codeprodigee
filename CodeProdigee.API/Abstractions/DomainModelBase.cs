using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeProdigee.API.Abstractions
{
    public abstract class DomainModelBase : IDomainModel
    {
        public DomainModelBase()
        {
            if (ID == Guid.Empty)
                ID = Guid.NewGuid();
            if (CreatedAt == DateTimeOffset.MinValue)
                CreatedAt = DateTimeOffset.UtcNow;
            UpdatedAt = CreatedAt;
        }
        public Guid ID { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public string CreatedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
