
using Microsoft.AspNetCore.Identity;
using SecurityDriven.Core;
using System;

namespace CodeProdigee.API.Abstractions
{
    public abstract class DomainModelBase : IDomainModel
    {
        public DomainModelBase()
        {
            var cryptorand = new CryptoRandom();
            if (ID == Guid.Empty)
                ID = cryptorand.NextGuid();
            if (CreatedAt == DateTime.MinValue)
                CreatedAt = DateTime.UtcNow;
            UpdatedAt = CreatedAt;
        }
        public Guid ID { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public string CreatedBy { get; set; }
        public bool IsDeleted { get; set; }
    }

    public class BaseIdentityUser : IdentityUser
    {
        public BaseIdentityUser()
        {
            if (CreatedAt == DateTime.MinValue)
                CreatedAt = DateTime.UtcNow;
            UpdatedAt = CreatedAt;
        }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public string CreatedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
