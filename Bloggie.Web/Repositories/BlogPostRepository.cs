using GeekHub.Web.Data;
using GeekHub.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace GeekHub.Web.Repositories
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly GeekHubDbContext GeekHubDbContext;

        public BlogPostRepository(GeekHubDbContext GeekHubDbContext) 
        {
            this.GeekHubDbContext = GeekHubDbContext;
        }

        public async Task<BlogPost> AddAsync(BlogPost blogPost)
        {
            await GeekHubDbContext.BlogPosts.AddAsync(blogPost);
            await GeekHubDbContext.SaveChangesAsync();

            return blogPost;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var existingBlogPost = await GeekHubDbContext.BlogPosts.FindAsync(id);
            
            if (existingBlogPost != null)
            {
                GeekHubDbContext.BlogPosts.Remove(existingBlogPost);
                await GeekHubDbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<IEnumerable<BlogPost>> GetAllAsync()
        {
            return await GeekHubDbContext.BlogPosts.Include(nameof(BlogPost.Tags)).ToListAsync();
        }

        public async Task<IEnumerable<BlogPost>> GetAllAsync(string tagName)
        {
            return await (GeekHubDbContext.BlogPosts.Include(nameof(BlogPost.Tags))
                .Where(x => x.Tags.Any(x => x.Name == tagName)))
                .ToListAsync();
        }

        public async Task<BlogPost> GetAsync(Guid id)
        {
            return await GeekHubDbContext.BlogPosts.Include(nameof(BlogPost.Tags))
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<BlogPost> GetAsync(string urlHandle)
        {
            return await GeekHubDbContext.BlogPosts.Include(nameof(BlogPost.Tags))
                .FirstOrDefaultAsync(x => x.UrlHandle == urlHandle);
        }

        public async Task<BlogPost> UpdateAsync(BlogPost blogPost)
        {
            var existingBlogPost = await GeekHubDbContext.BlogPosts.Include(nameof(BlogPost.Tags))
                .FirstOrDefaultAsync(x => x.Id == blogPost.Id);

            if (existingBlogPost != null)
            {
                existingBlogPost.Heading = blogPost.Heading;
                existingBlogPost.PageTitle = blogPost.PageTitle;
                existingBlogPost.Content = blogPost.Content;
                existingBlogPost.ShortDescription = blogPost.ShortDescription;
                existingBlogPost.FeaturedImageUrl = blogPost.FeaturedImageUrl;
                existingBlogPost.UrlHandle = blogPost.UrlHandle;
                existingBlogPost.PublishedDate = blogPost.PublishedDate;
                existingBlogPost.Author = blogPost.Author;
                existingBlogPost.Visible = blogPost.Visible;

                if (blogPost.Tags != null && blogPost.Tags.Any())
                {
                    GeekHubDbContext.Tags.RemoveRange(existingBlogPost.Tags);

                    blogPost.Tags.ToList().ForEach(x => x.BlogPostId = existingBlogPost.Id);
                    await GeekHubDbContext.Tags.AddRangeAsync(blogPost.Tags);
                }
            }

            await GeekHubDbContext.SaveChangesAsync();

            return existingBlogPost;
        }
    }
}