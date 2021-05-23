using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicCore.Interfaces;
using BusinessLogicCore.MapperProfiles;
using FluentResults;
using Models;
using ScientificDatabase.Models.Hierarchy;
using ScientificDatabase.Models.TypeObject;
using ScientificDatabase.Repositories;
using ScientificDatabase.Repositories.HierarchyRepository;
using ScientificDatabase.Repositories.TypeObjectRepositopy;
using ScientificDatabase.Repositories.TypeObjectRepository;

namespace BusinessLogicCore.Service
{
    public class SectionService : ISectionService
    {
        private SectionRepositopy _sectionRepositopy;
        private TypeObjectRepository _typeObjectRepositopy;
        private DataObjectRepository _dataObjectRepository;
        private ValueRepository _valueRepository;
        private PropertiesRepository _propertiesRepository;

        private IMapperProvider _mapperProvider;

        public SectionService(ValueRepository valueRepository, SectionRepositopy sectionRepositopy,
            IMapperProvider mapperProvider, TypeObjectRepository typeObjectRepositopy,
            DataObjectRepository dataObjectRepository, PropertiesRepository propertiesRepository)
        {
            _sectionRepositopy = sectionRepositopy;
            _mapperProvider = mapperProvider;
            _typeObjectRepositopy = typeObjectRepositopy;
            _dataObjectRepository = dataObjectRepository;
            _valueRepository = valueRepository;
            _propertiesRepository = propertiesRepository;
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
        // public async Task<Result> AddSectionAsync(SectionDto sectionDto)
        // {
        //     try
        //     {
        //         var result = _mapperProvider.CreateMap<SectionDto, Section>(sectionDto);
        //         var mainSection = await _sectionRepositopy.InsertItemAsync(result);
        //         return Result.Ok();
        //     }
        //     catch (Exception ex)
        //     {
        //         return Result.Fail("При получении списка разделов произошла ошибка.");
        //     }
        // }
    }
}