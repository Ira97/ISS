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
                var mainSection = await _sectionRepositopy.GetItemAsync(id);
                var listSection = await _sectionRepositopy.GetListAsync(x => x.ParentId == id);
                var typeObjectList =
                    await _typeObjectRepositopy.GetListAsync(x => x.SectionId == listSection.FirstOrDefault().Id);
                var dataObjects = new List<DataObject>();
                var properties = new List<Property>();
                foreach (var typeObject in typeObjectList)
                {
                    dataObjects.AddRange(
                        await _dataObjectRepository.GetListAsync(x => x.TypeObjectId == typeObject.Id));
                    properties.AddRange(await _propertiesRepository.GetPropertyListAsync());
                }

                var valueForDataObject = new List<ValuePropertyObject>();
                foreach (var dataObject in dataObjects)
                {
                    valueForDataObject.AddRange(await  _valueRepository.GetListAsync(x=>x.DataObjectId== dataObject.Id));
                }
                
                var mapMainSection = _mapperProvider.CreateMap<Section, MainSectionDto>(mainSection);

                // var resultValue = await _valueRepository.GetListAsync(x => x.DataObjectId == listObj.Id);
                // // dataObjects.AddRange(resultValue);
                // //
                // mapMainSection.SectionDtos = _mapperProvider.CreateMapForList<Section, SectionDto>(listSection);
                // mapMainSection.TypeObjectDtos =
                //     _mapperProvider.CreateMapForList<ScientificDatabase.Models.TypeObject.TypeObject, TypeObjectDto>(
                //         typeObjectList);
                // var list = new List<DataObject>();
                // list.Add(listObj);
                //
                // mapMainSection.DataObjectDtos = _mapperProvider.CreateMapForList<DataObject, DataObjectDto>(list);
                // TypeObjectDto typeObject1 = null;
                // foreach (var data in list)
                // {
                //     var d = data.TypeObject;
                //     typeObject1 = _mapperProvider
                //         .CreateMapByProfile<ScientificDatabase.Models.TypeObject.TypeObject, TypeObjectDto,
                //             BaseProfile>(d);
                //     var value =
                //         _mapperProvider.CreateMapForList<ValuePropertyObject, ValuePropertyObjectDto>(
                //             data.ValuePropertyObjects);
                //     var v = mapMainSection.DataObjectDtos.Where(x => x.Id == data.Id);
                //     v.FirstOrDefault().ValuePropertyObjectDtos = value;
                //     v.FirstOrDefault().TypeObjectDto = typeObject1;
                //
                //     foreach (var b in data.ValuePropertyObjects)
                //     {
                //         b.Property = await _propertiesRepository.GetItemAsync(b.PropertyId);
                //         v.FirstOrDefault().ValuePropertyObjectDtos.ForEach(x =>
                //             x.Property = _mapperProvider.CreateMap<Property, PropertyDto>(b.Property));
                //     }

                //     return Result.Ok(mapMainSection);
                // }

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