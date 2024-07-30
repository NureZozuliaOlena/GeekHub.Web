using GeekHub.Web.Data;
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

        public async Task<int> GetTotalLikesForBlog(Guid blogPostId)
        {
            return await geekHubDbContext.BlogPostLike
                .CountAsync(x => x.BlogPostId == blogPostId);
        }
    }
}