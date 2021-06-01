using System;
using System.Threading.Tasks;
using BusinessLogicCore.Interfaces;
using BusinessLogicCore.MapperProfiles;
using FluentResults;
using Models;
using ScientificDatabase.Models.Hierarchy;
using ScientificDatabase.Repositories.HierarchyRepository;

namespace BusinessLogicCore.Service
{
    public class SectionService : ISectionService
    {
        private SectionRepositopy _sectionRepositopy;
        private IMapperProvider _mapperProvider;

        public SectionService(SectionRepositopy sectionRepositopy,
            IMapperProvider mapperProvider)
        {
            _sectionRepositopy = sectionRepositopy;
            _mapperProvider = mapperProvider;
        }

        public async Task<Result> CreateSectionAsync(SectionDto sectionDto)
        {
            try
            {
                var result = _mapperProvider.CreateMapByProfile<SectionDto, Section, BaseProfile>(sectionDto);
                await _sectionRepositopy.InsertItemAsync(result);
                return Result.Ok();
            }
            catch (Exception ex)
            {
                return Result.Fail("При создании раздела науки возникла ошибка.");
            }
        }

        public async Task<Result<MainSectionDto>> GetSectionsAsync(int id)
        {
            try
            {
                var mainSection = _sectionRepositopy.GetSectionAsync(id);
                var listSection = await _sectionRepositopy.GetListAsync(x => x.ParentId == id);           
                var mapMainSection = _mapperProvider.CreateMapByProfile<Section, MainSectionDto, BaseProfile>(mainSection);
                var mappedSectionList = _mapperProvider.CreateMapForList<Section, SectionDto>(listSection);
                mapMainSection.SectionDtos = mappedSectionList;
                return Result.Ok(mapMainSection);
            }
            catch (Exception ex)
            {
                return Result.Fail("При получении списка разделов произошла ошибка.");
            }
        }
    }
}