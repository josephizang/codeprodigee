using CodeProdigee.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeProdigee.API.TypeConfigurations
{
    public class AuthorEntityTypeConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.Property(a => a.AuthorName)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(a => a.AuthorEmail)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(a => a.AuthorTwitter)
                .HasMaxLength(50);
            builder.HasMany(a => a.AuthorPosts)
                .WithOne(p => p.PostAuthor)
                .HasForeignKey(p => p.AuthorID);
            builder.HasMany(a => a.AuthorComments)
                .WithOne();
        }
    }
}