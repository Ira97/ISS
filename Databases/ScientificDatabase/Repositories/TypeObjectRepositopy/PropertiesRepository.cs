using CacheManager.Core;
using Microsoft.Extensions.Logging;
using ScientificDatabase.Models;
using ScientificDatabase.Models.TypeObject;

namespace ScientificDatabase.Repositories.TypeObjectRepositopy
{
    public class PropertiesRepository: BaseRepository<Properties>
    {
        protected PropertiesRepository(ScientificContext dbContext, ICacheManager<object> cacheManager, ILogger<BaseRepository<Properties>> logger) : base(dbContext, cacheManager, logger)
        {
        }
    }
}