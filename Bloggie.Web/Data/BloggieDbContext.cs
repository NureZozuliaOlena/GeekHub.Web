using GeekHub.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace GeekHub.Web.Data
{
    public class GeekHubDbContext : DbContext
    {
        public GeekHubDbContext(DbContextOptions<GeekHubDbContext> options) : base(options)
        {
        }

        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}
