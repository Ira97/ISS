using CacheManager.Core;
using Microsoft.Extensions.Logging;
using ScientificDatabase.Models;
using ScientificDatabase.Models.TypeObject;

namespace ScientificDatabase.Repositories
{
    public class ResearchRepository : BaseRepository<Research>
    {
        public ResearchRepository(ScientificContext dbContext, ICacheManager<object> cacheManager, ILogger<BaseRepository<Research>> logger) : base(dbContext, cacheManager, logger)
        {
        }
    }
}