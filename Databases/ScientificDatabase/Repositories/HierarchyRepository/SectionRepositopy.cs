using System.Linq;
using CacheManager.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ScientificDatabase.Models;
using ScientificDatabase.Models.Hierarchy;

namespace ScientificDatabase.Repositories.HierarchyRepository
{
    public class SectionRepositopy: BaseRepository<Section>
    {
        public SectionRepositopy(ScientificContext dbContext, ICacheManager<object> cacheManager, ILogger<BaseRepository<Section>> logger) : base(dbContext, cacheManager, logger)
        {
        }
    }
}