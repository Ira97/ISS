using System.Linq;
using CacheManager.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ScientificDatabase.Models;

namespace ScientificDatabase.Repositories.UserRepository
{
    public class RoleRepository : BaseRepository<Role>
    {
        public RoleRepository(ScientificContext dbContext, ICacheManager<object> cacheManager,
            ILogger<BaseRepository<Role>> logger) : base(dbContext, cacheManager, logger)
        {
        }

    
    }
}