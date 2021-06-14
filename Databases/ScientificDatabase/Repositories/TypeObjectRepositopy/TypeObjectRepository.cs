using CacheManager.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ScientificDatabase.Models;
using ScientificDatabase.Models.TypeObject;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ScientificDatabase.Repositories.TypeObjectRepository
{
    public class TypeObjectRepository : BaseRepository<TypeObject>
    {
        public TypeObjectRepository(ScientificContext dbContext, ICacheManager<object> cacheManager, ILogger<BaseRepository<TypeObject>> logger) : base(dbContext, cacheManager, logger)
        {
        }

        public async Task<TypeObject> GetTypeObjectAsync(int id)
        {
            var typeObject = ScientificContext.TypeObjects.Include(x => x.Properties).FirstOrDefault(x => x.Id == id);
            return typeObject;
        }

        //public Task GetTypeObjectListAsync(int sectionId)
        //{
        //    var typeObjectList = ScientificContext.Type
        //}
    }
}