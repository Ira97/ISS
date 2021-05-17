using CacheManager.Core;
using Microsoft.Extensions.Logging;
using ScientificDatabase.Models;
using ScientificDatabase.Models.TypeObject;

namespace ScientificDatabase.Repositories.TypeObjectRepositopy
{
    public class TypeObjectRepositopy : BaseRepository<TypeObject>
    {
        protected TypeObjectRepositopy(ScientificContext dbContext, ICacheManager<object> cacheManager, ILogger<BaseRepository<TypeObject>> logger) : base(dbContext, cacheManager, logger)
        {
        }
    }
}