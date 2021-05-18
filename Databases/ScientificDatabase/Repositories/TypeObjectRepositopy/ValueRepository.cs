using CacheManager.Core;
using Microsoft.Extensions.Logging;
using ScientificDatabase.Models;
using ScientificDatabase.Models.TypeObject;

namespace ScientificDatabase.Repositories.TypeObjectRepositopy
{
    public class ValueRepository: BaseRepository<ValuePropertyObject>
    {
        public ValueRepository(ScientificContext dbContext, ICacheManager<object> cacheManager, ILogger<BaseRepository<ValuePropertyObject>> logger) : base(dbContext, cacheManager, logger)
        {
        }
    }
}