using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WebApiHandlers.Interfaces
{
    public interface IAreaProvider
    {
        Task<AreaDto> GetAreaAsync(int id);
        Task<List<AreaDto>> GetAreaListAsync();
        Task CreateAreaAsync(AreaDto areaDto);
    }
}
