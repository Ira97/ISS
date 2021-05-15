using CacheManager.Core;
using Microsoft.Extensions.Logging;
using ScientificDatabase.Models;
using ScientificDatabase.Models.Hierarchy;

namespace ScientificDatabase.Repositories
{
    public class AreaSectionRepositiry: BaseRepository<AreaSection>
    {
        protected AreaSectionRepositiry(ScientificContext dbContext, ICacheManager<object> cacheManager, ILogger<BaseRepository<AreaSection>> logger) : base(dbContext, cacheManager, logger)
        {
        }
    }
}