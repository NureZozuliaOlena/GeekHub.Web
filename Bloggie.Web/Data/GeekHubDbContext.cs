using GeekHub.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace GeekHub.Web.Data
{
    public class GeekHubDbContext : DbContext
    {
        public GeekHubDbContext(DbContextOptions<GeekHubDbContext> options) : base(options)
        {
        }

        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<BlogPostLike> BlogPostLike { get; set; }
        public DbSet<BlogPostComment> BlogPostComment { get; set; }
    }
}