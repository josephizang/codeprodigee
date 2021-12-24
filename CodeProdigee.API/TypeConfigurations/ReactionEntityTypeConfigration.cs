using CodeProdigee.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeProdigee.API.TypeConfigurations
{
    public class ReactionEntityTypeConfigration : IEntityTypeConfiguration<Reaction>
    {
        public void Configure(EntityTypeBuilder<Reaction> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(r => r.Email)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
