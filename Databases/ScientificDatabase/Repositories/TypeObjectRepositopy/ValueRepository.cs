using CacheManager.Core;
using Microsoft.Extensions.Logging;
using ScientificDatabase.Models;
using ScientificDatabase.Models.TypeObject;

namespace ScientificDatabase.Repositories.TypeObjectRepositopy
{
    public class ValueRepository: BaseRepository<ValuePropertiesObject>
    {
        protected ValueRepository(ScientificContext dbContext, ICacheManager<object> cacheManager, ILogger<BaseRepository<ValuePropertiesObject>> logger) : base(dbContext, cacheManager, logger)
        {
        }
    }
}