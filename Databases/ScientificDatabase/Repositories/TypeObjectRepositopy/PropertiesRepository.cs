using CacheManager.Core;
using Microsoft.Extensions.Logging;
using ScientificDatabase.Models;
using ScientificDatabase.Models.TypeObject;

namespace ScientificDatabase.Repositories.TypeObjectRepositopy
{
    public class PropertiesRepository: BaseRepository<Property>
    {
        protected PropertiesRepository(ScientificContext dbContext, ICacheManager<object> cacheManager, ILogger<BaseRepository<Property>> logger) : base(dbContext, cacheManager, logger)
        {
        }
    }
}