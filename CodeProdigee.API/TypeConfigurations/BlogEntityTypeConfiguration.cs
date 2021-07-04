using CodeProdigee.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeProdigee.API.TypeConfigurations
{
    public class BlogEntityTypeConfiguration : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.Property(b => b.AdminName)
                .IsRequired()
                .HasMaxLength(150);
            builder.Property(b => b.BlogAdminEmail)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(b => b.BlogName)
                .HasMaxLength(200)
                .IsRequired();
            builder.HasMany(b => b.Posts)
                .WithOne();
        }
    }
}
