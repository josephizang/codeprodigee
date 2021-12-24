using CodeProdigee.API.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CodeProdigee.API.Data
{
    public class CodeProdigeeContext : IdentityDbContext<ApplicationUser>
    {
        public CodeProdigeeContext(DbContextOptions<CodeProdigeeContext> options) : base(options)
        {

        }

        public CodeProdigeeContext()
        {

        }

        public DbSet<Blog> Blogs { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<Resource> Resources { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Commentator> Commentators { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(Startup).Assembly);

            builder.Entity<Post>()
                .HasQueryFilter(p => !p.IsDeleted);
            builder.Entity<ApplicationUser>()
                .HasQueryFilter(p => !p.IsDeleted);
            builder.Entity<Blog>()
                .HasQueryFilter(p => !p.IsDeleted);
            builder.Entity<Tag>()
                .HasQueryFilter(p => !p.IsDeleted);
            builder.Entity<Reaction>()
                .HasQueryFilter(p => !p.IsDeleted);
            builder.Entity<Resource>()
                .HasQueryFilter(p => !p.IsDeleted);
            builder.Entity<Comment>()
                .HasQueryFilter(p => !p.IsDeleted);
            builder.Entity<Commentator>()
                .HasQueryFilter(p => !p.IsDeleted);
            builder.Entity<CommentReply>()
                .HasQueryFilter(p => !p.IsDeleted);

            builder.Entity<Post>()
                .HasMany(p => p.Tags)
                .WithMany(t => t.Posts);
            builder.Entity<Post>()
                .HasMany(p => p.Resources)
                .WithMany(r => r.Posts);
        }
    }
}
