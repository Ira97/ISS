using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CacheManager.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ScientificDatabase.Models;
using ScientificDatabase.Models.TypeObject;

namespace ScientificDatabase.Repositories.TypeObjectRepositopy
{
    public class PropertiesRepository: BaseRepository<Property>
    {
        public PropertiesRepository(ScientificContext dbContext, ICacheManager<object> cacheManager, ILogger<BaseRepository<Property>> logger) : base(dbContext, cacheManager, logger)
        {
        }

        public async Task<IEnumerable<Property>> GetPropertyListAsync()
        {
            var list = ScientificContext.Properties.Include(x => x.TypeObjects).Where(x => x.)
        }
    }
}