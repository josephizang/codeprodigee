using CodeProdigee.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeProdigee.API.Data
{
    public class CodeProdigeeContext : DbContext
    {
        public CodeProdigeeContext(DbContextOptions<CodeProdigeeContext> options) : base(options)
        {

        }

        public CodeProdigeeContext()
        {

        }

        public DbSet<Blog> Blogs { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<Resource> Resources { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Commentator> Commentators { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(Startup).Assembly);

            builder.Entity<Post>()
                .HasQueryFilter(p => !p.IsDeleted);
            builder.Entity<Author>()
                .HasQueryFilter(p => !p.IsDeleted);
            builder.Entity<Blog>()
                .HasQueryFilter(p => !p.IsDeleted);
            builder.Entity<Tag>()
                .HasQueryFilter(p => !p.IsDeleted);
            builder.Entity<Resource>()
                .HasQueryFilter(p => !p.IsDeleted);
            builder.Entity<Comment>()
                .HasQueryFilter(p => !p.IsDeleted);
            builder.Entity<Commentator>()
                .HasQueryFilter(p => !p.IsDeleted);

            builder.Entity<Post>()
                .HasMany(p => p.PostTags)
                .WithOne()
                .HasForeignKey(pt => pt.PostID);
            builder.Entity<Tag>()
                .HasMany(t => t.PostTags)
                .WithOne()
                .HasForeignKey(pt => pt.TagID);
            builder.Entity<Post>()
                .HasMany(p => p.PostResources)
                .WithOne()
                .HasForeignKey(pr => pr.PostID);
            builder.Entity<Resource>()
                .HasMany(r => r.PostResources)
                .WithOne()
                .HasForeignKey(pr => pr.ResourceID);

            builder.Entity<PostResources>()
                .HasKey(pr => new { pr.PostID, pr.ResourceID });
            builder.Entity<PostTags>()
                .HasKey(pt => new { pt.PostID, pt.TagID });
        }
    }
}
