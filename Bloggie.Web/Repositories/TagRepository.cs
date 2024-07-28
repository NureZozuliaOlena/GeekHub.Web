using GeekHub.Web.Data;
using GeekHub.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace GeekHub.Web.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly GeekHubDbContext GeekHubDbContext;

        public TagRepository(GeekHubDbContext GeekHubDbContext)
        {
            this.GeekHubDbContext = GeekHubDbContext;
        }

        public async Task<IEnumerable<Tag>> GetAllAsync()
        {
            var tags = await GeekHubDbContext.Tags.ToListAsync();

            return tags.DistinctBy(x => x.Name.ToLower());
        }
    }
}