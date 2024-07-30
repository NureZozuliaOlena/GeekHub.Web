using GeekHub.Web.Data;
using GeekHub.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace GeekHub.Web.Repositories
{
    public class BlogPostLikeRepository : IBlogPostLikeRepository
    {
        private readonly GeekHubDbContext geekHubDbContext;

        public BlogPostLikeRepository(GeekHubDbContext geekHubDbContext)
        {
            this.geekHubDbContext = geekHubDbContext;
        }

        public async Task AddLikeForBlog(Guid blogPostId, Guid userId)
        {
            var like = new BlogPostLike
            {
                Id = Guid.NewGuid(),
                BlogPostId = blogPostId,
                UserId = userId
            };

            await geekHubDbContext.BlogPostLike.AddAsync(like);
            await geekHubDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<BlogPostLike>> GetLikesForBlog(Guid blogPostId)
        {
            return await geekHubDbContext.BlogPostLike.Where(x => x.BlogPostId == blogPostId)
                .ToListAsync();
        }

        public async Task<int> GetTotalLikesForBlog(Guid blogPostId)
        {
            return await geekHubDbContext.BlogPostLike
                .CountAsync(x => x.BlogPostId == blogPostId);
        }
    }
}