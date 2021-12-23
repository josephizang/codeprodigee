using CodeProdigee.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeProdigee.API.TypeConfigurations
{
    public class AuthorEntityTypeConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(a => a.AuthorTwitter)
                .HasMaxLength(50);
            builder.Property(a => a.AuthorGithub)
                .HasMaxLength(50);
            builder.Property(a => a.Bio)
                .HasMaxLength(500);
            builder.HasMany(a => a.AuthorPosts)
                .WithOne(p => p.PostAuthor)
                .HasForeignKey(p => p.AuthorID);
            builder.HasMany(a => a.AuthorComments)
                .WithOne();
        }
    }
}