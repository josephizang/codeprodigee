using CodeProdigee.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeProdigee.API.TypeConfigurations
{
    public class PostEntityTypeConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(p => p.ID);
            builder.Property(p => p.PostBody)
                .HasMaxLength(3000)
                .IsRequired();
            builder.Property(p => p.PostDate)
                .IsRequired();
            builder.HasMany(p => p.Resources)
                .WithMany(r => r.Posts);
            builder.HasMany(p => p.Tags)
                .WithMany(t => t.Posts);
            builder.Property(p => p.UpdatedBy)
                .HasMaxLength(50);
            builder.Property(p => p.CreatedBy)
                .HasMaxLength(50);
            builder.Property(p => p.PostTitle)
                .HasMaxLength(200)
                .IsRequired();
            builder.HasIndex(p => p.PostTitle)
                .IsUnique();
            builder.HasIndex(p => p.PublishDate);
            
        }
    }
}
