using CacheManager.Core;
using Microsoft.Extensions.Logging;
using ScientificDatabase.Models;
using ScientificDatabase.Models.TypeObject;
using System;
using System.Threading.Tasks;

namespace ScientificDatabase.Repositories.TypeObjectRepository
{
    public class TypeObjectRepository : BaseRepository<TypeObject>
    {
        public TypeObjectRepository(ScientificContext dbContext, ICacheManager<object> cacheManager, ILogger<BaseRepository<TypeObject>> logger) : base(dbContext, cacheManager, logger)
        {
        }

        //public Task GetTypeObjectListAsync(int sectionId)
        //{
        //    var typeObjectList = ScientificContext.Type
        //}
    }
}