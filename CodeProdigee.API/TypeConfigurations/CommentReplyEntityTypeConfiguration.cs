using CodeProdigee.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeProdigee.API.TypeConfigurations
{
    public class CommentReplyEntityTypeConfiguration : IEntityTypeConfiguration<CommentReply>
    {
        public void Configure(EntityTypeBuilder<CommentReply> builder)
        {
            builder.HasKey(x => x.ID);
            builder.HasMany(r => r.Reactions)
                .WithOne();
            builder.Property(r => r.ReplyBody)
                .HasMaxLength(500);
            builder.HasOne(r => r.Comment)
                .WithMany(c => c.Replies)
                .HasForeignKey(r => r.CommentId);
        }
    }
}
