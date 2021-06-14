using System.Collections.Generic;
using System.Threading.Tasks;
using FluentResults;
using Models;

namespace BusinessLogicCore.Service
{
    public interface ISectionService
    {
        Task<Result> CreateSectionAsync(SectionDto sectionDto);
        Task<Result<MainSectionDto>> GetSectionsAsync(int id);
        Task<Result> CreateResearchAsync(ResearchDto research);
        Task<Result> CreateDataObjectAsync(DataObjectDto objectDto);
        Task<Result<List<PropertyDto>>> GetPropertyListAsync();
        Task<Result<List<MethodDto>>> GetMethodListAsync();
        Task<Result<List<DataObjectDto>>> GetDataObjectListAsync();
        Task<Result<List<SectionDto>>> GetSectionListAsync();
        Task<Result<TypeObjectDto>> GetTypeObjectAsync(int id);
    }
}