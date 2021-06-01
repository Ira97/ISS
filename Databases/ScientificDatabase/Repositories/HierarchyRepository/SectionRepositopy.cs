using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CacheManager.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ScientificDatabase.Models;
using ScientificDatabase.Models.Hierarchy;

namespace ScientificDatabase.Repositories.HierarchyRepository
{
    public class SectionRepositopy: BaseRepository<Section>
    {
        public SectionRepositopy(ScientificContext dbContext, ICacheManager<object> cacheManager,
            ILogger<BaseRepository<Section>> logger) : base(dbContext, cacheManager, logger)
        {
        }

        public Section GetSectionAsync(int id)
        {
            var section = ScientificContext.Sections.
                Include(s => s.TypeObjects).
                ThenInclude(t => t.Properties).
                Include(s => s.TypeObjects).
                ThenInclude(t => t.DataObjects).
                ThenInclude(d => d.ValuePropertyObjects).
                Include(s => s.Researches).
                ThenInclude(r => r.DataObjects).
                ToList().
                SingleOrDefault(s => s.Id == id);
            return section;
        }
    }
}