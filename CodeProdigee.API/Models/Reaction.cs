using CodeProdigee.API.Abstractions;

namespace CodeProdigee.API.Models
{
    public class Reaction : DomainModelBase
    {
        public bool Like { get; set; }

        public bool DisLike { get; set; }

        public string Email { get; set; }
    }
}
