using CodeProdigee.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeProdigee.API.TypeConfigurations
{
    public class CommentEntityTypeConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(c => c.CommentBody)
                .HasMaxLength(1000)
                .IsRequired();
            builder.HasMany(c => c.Replies)
                .WithOne();
            builder.HasOne(c => c.Post)
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.PostID);
            builder.HasOne(c => c.CommentAuthor)
                .WithMany(c => c.CommentatorComments)
                .HasForeignKey(c => c.CommentAuthorID);
            builder.Property(c => c.Title)
                .HasMaxLength(150)
                .IsRequired();
        }
    }
}
