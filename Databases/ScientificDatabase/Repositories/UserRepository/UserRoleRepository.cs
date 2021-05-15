using System.Linq;
using CacheManager.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ScientificDatabase.Models;

namespace ScientificDatabase.Repositories.UserRepository
{
    public class UserRoleRepository : BaseRepository<UserRole>
    {
        public UserRoleRepository(ScientificContext dbContext, ICacheManager<object> cacheManager,
            ILogger<BaseRepository<UserRole>> logger) : base(dbContext, cacheManager, logger)
        {
        }

     
    }
}