using CodeProdigee.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeProdigee.API.TypeConfigurations
{
    public class CommentatorEntityTypeConfiguration : IEntityTypeConfiguration<Commentator>
    {
        public void Configure(EntityTypeBuilder<Commentator> builder)
        {
            builder.Property(c => c.Email)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(c => c.FullName)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
