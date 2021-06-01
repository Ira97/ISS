using CacheManager.Core;
using Microsoft.Extensions.Logging;
using ScientificDatabase.Models;
using ScientificDatabase.Models.TypeObject;

namespace ScientificDatabase.Repositories.TypeObjectRepositopy
{
    public class DataObjectRepository : BaseRepository<DataObject>
    {
        public DataObjectRepository(ScientificContext dbContext, ICacheManager<object> cacheManager, ILogger<BaseRepository<DataObject>> logger) : base(dbContext, cacheManager, logger)
        {
        }
    }
}