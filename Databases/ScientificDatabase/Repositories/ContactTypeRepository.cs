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
    public class ContactTypeRepository: BaseRepository<ContactType>
    {
        public ContactTypeRepository(ScientificContext dbContext, ICacheManager<object> cacheManager, ILogger<BaseRepository<ContactType>> logger) : base(dbContext, cacheManager, logger)
        {
        }
    }
}