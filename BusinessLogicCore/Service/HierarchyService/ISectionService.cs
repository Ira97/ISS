using System.Threading.Tasks;
using FluentResults;
using Models;

namespace BusinessLogicCore.Service
{
    public interface ISectionService
    {
        Task<Result> CreateSectionAsync(SectionDto sectionDto);
    }
}