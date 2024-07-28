using GeekHub.Web.Models.Domain;

namespace GeekHub.Web.Repositories
{
    public interface ITagRepository
    {
        Task<IEnumerable<Tag>> GetAllAsync();
    }
}
