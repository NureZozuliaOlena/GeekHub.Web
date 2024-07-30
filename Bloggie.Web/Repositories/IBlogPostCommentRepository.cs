using GeekHub.Web.Models.Domain;

namespace GeekHub.Web.Repositories
{
    public interface IBlogPostCommentRepository
    {
        Task<BlogPostComment> AddAsync(BlogPostComment blogPostComment);
        Task<IEnumerable<BlogPostComment>> GetAllAsync(Guid blogPostId);
    }
}