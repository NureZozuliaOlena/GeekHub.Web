using Microsoft.AspNetCore.Identity;

namespace GeekHub.Web.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<IdentityUser>> GetAll();
    }
}