using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogicCore.Interfaces;
using BusinessLogicCore.MapperProfiles;
using FluentResults;
using Models;
using ScientificDatabase.Models;
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
        private PropertiesRepository _propertiesRepository;
        private ResearchRepository _researchRepository;
        private DataObjectRepository _dataObjectRepository;
        private TypeObjectRepository _typeObjectRepository;
        private IMapperProvider _mapperProvider;

        public SectionService(SectionRepositopy sectionRepositopy,
            IMapperProvider mapperProvider, ResearchRepository researchRepository, DataObjectRepository dataObjectRepository, PropertiesRepository propertiesRepository, TypeObjectRepository typeObjectRepository)
        {
            _sectionRepositopy = sectionRepositopy;
            _mapperProvider = mapperProvider;
            _researchRepository = researchRepository;
            _dataObjectRepository = dataObjectRepository;
            _propertiesRepository = propertiesRepository;
            _typeObjectRepository = typeObjectRepository;
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
                mapMainSection.TypeObjects.ForEach(x => x.DataObjects.ForEach(y => y.TypeObject = null));
                return Result.Ok(mapMainSection);
            }
            catch (Exception ex)
            {
                return Result.Fail("При получении списка разделов произошла ошибка.");
            }
        }

        public async Task<Result> CreateResearchAsync(ResearchDto research)
        {
            try
            {
                var result = _mapperProvider.CreateMapByProfile<ResearchDto, Research, BaseProfile>(research);
                await _researchRepository.InsertItemAsync(result);
                return Result.Ok();
            }
            catch (Exception ex)
            {
                return Result.Fail("При создании исследования возникла ошибка.");
            }
        }

        public async Task<Result> CreateDataObjectAsync(DataObjectDto objectDto)
        {
            try
            {
                var result = _mapperProvider.CreateMapByProfile<DataObjectDto, DataObject, BaseProfile>(objectDto);
                await _dataObjectRepository.InsertItemAsync(result);
                return Result.Ok();
            }
            catch (Exception ex)
            {
                return Result.Fail("При создании исследования возникла ошибка.");
            }
        }

        public async Task<Result<List<PropertyDto>>> GetPropertyListAsync()
        {
            var list = await _propertiesRepository.GetItemsAsync();
            var mappedList = _mapperProvider.CreateMapForList<Property, PropertyDto>(list);
            return Result.Ok(mappedList);
        }
        public async Task<Result<List<MethodDto>>> GetMethodListAsync()
        {
            //var list = await _dataObjectRepository.GetItemsAsync();
            //var mappedList = _mapperProvider.CreateMapForList<DataObject, DataObjectDto>(list);
            return Result.Ok(new List<MethodDto>());
        }
        public async Task<Result<List<DataObjectDto>>> GetDataObjectListAsync()
        {
            var list = await _dataObjectRepository.GetItemsAsync();
            var mappedList = _mapperProvider.CreateMapForList<DataObject, DataObjectDto>(list);
            return Result.Ok(mappedList);
        }

        public async Task<Result<List<SectionDto>>> GetSectionListAsync()
        {
            var list = await _sectionRepositopy.GetItemsAsync();
            var mappedList = _mapperProvider.CreateMapForList<Section, SectionDto>(list);
            return Result.Ok(mappedList);
        }

        public async Task<Result<TypeObjectDto>> GetTypeObjectAsync(int id)
        {
            var item = await _typeObjectRepository.GetTypeObjectAsync(id);
            var mappedList = _mapperProvider.CreateMapByProfile<ScientificDatabase.Models.TypeObject.TypeObject, TypeObjectDto, BaseProfile>(item);
            return Result.Ok(mappedList);
        }


    }
}