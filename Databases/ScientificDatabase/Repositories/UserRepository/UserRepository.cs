using System.Linq;
using CacheManager.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ScientificDatabase.Models;

namespace ScientificDatabase.Repositories.UserRepository
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(ScientificContext dbContext, ICacheManager<object> cacheManager,
            ILogger<BaseRepository<User>> logger) : base(dbContext, cacheManager, logger)
        {
        }

        public User GetUserAsync(string login, string hashPassword)
        {
            var user = ScientificContext.User
                .Include(x => x.Role)
                .Where(x => x.Login == login && x.Password == hashPassword).ToList().FirstOrDefault();

            return user;
        }
    }
}