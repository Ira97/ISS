using System.Collections.Generic;
using System.Threading.Tasks;
using FluentResults;
using Models;

namespace BusinessLogicCore.Service
{
    public interface IAreaService
    {
        Task<Result> CreateAreaAsync(AreaDto areaDto);
        Task<Result<List<AreaDto>>> GetAreasAsync();
        Task<Result<AreaDto>> GetSectionsForAreaAsync(int areaId);
    }
}