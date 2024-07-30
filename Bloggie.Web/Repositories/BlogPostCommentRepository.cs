using GeekHub.Web.Data;
using GeekHub.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace GeekHub.Web.Repositories
{
    public class BlogPostCommentRepository : IBlogPostCommentRepository
    {
        private readonly GeekHubDbContext geekHubDbContext;

        public BlogPostCommentRepository(GeekHubDbContext geekHubDbContext)
        {
            this.geekHubDbContext = geekHubDbContext;
        }

        public async Task<BlogPostComment> AddAsync(BlogPostComment blogPostComment)
        {
            await geekHubDbContext.BlogPostComment.AddAsync(blogPostComment);
            await geekHubDbContext.SaveChangesAsync();
            return blogPostComment;
        }

        public async Task<IEnumerable<BlogPostComment>> GetAllAsync(Guid blogPostId)
        {
            return await geekHubDbContext.BlogPostComment.Where(x => x.BlogPostId == blogPostId)
                .ToListAsync();
        }
    }
}