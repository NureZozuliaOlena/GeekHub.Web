namespace GeekHub.Web.Repositories
{
    public interface IBlogPostLikeRepository
    {
        Task<int> GetTotalLikesForBlog(Guid blogPostId);
    }
}