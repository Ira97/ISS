using System.Linq;
using System.Threading.Tasks;
using CacheManager.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ScientificDatabase.Models;
using ScientificDatabase.Models.Hierarchy;

namespace ScientificDatabase.Repositories.HierarchyRepository
{
    public class AreaRepository : BaseRepository<Area>
    {
        public AreaRepository(ScientificContext dbContext, ICacheManager<object> cacheManager,
            ILogger<BaseRepository<Area>> logger) : base(dbContext, cacheManager, logger)
        {
        }
        
        /// <summary>
        /// Получить разделы по идентификатору области 
        /// </summary>
        /// <param name="areaId"></param>
        /// <returns></returns>
        public async Task<Area> GetSectionAsync(int areaId)
        {
            var sections =await ScientificContext.Area
                .Include(x => x.Section)
                .SingleOrDefaultAsync(x => x.Id == areaId);
            return sections;
        }
    }
}