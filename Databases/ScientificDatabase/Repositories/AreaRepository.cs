using System.Linq;
using CacheManager.Core;
using Microsoft.Extensions.Logging;
using ScientificDatabase.Models;
using ScientificDatabase.Models.Hierarchy;

namespace ScientificDatabase.Repositories
{
    public class AreaRepository: BaseRepository<Area>
    {
        protected AreaRepository(ScientificContext dbContext, ICacheManager<object> cacheManager, ILogger<BaseRepository<Area>> logger) : base(dbContext, cacheManager, logger)
        {
        }
    }
}