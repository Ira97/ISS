using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogicCore.Interfaces;
using BusinessLogicCore.MapperProfiles;
using FluentResults;
using Models;
using ScientificDatabase.Models.Hierarchy;
using ScientificDatabase.Repositories;
using ScientificDatabase.Repositories.HierarchyRepository;
using ScientificDatabase.Repositories.TypeObjectRepositopy;

namespace BusinessLogicCore.Service
{
    public class SectionService : ISectionService
    {
        private SectionRepositopy _sectionRepositopy;
        private TypeObjectRepositopy _typeObjectRepositopy;
        private DataObjectRepository _dataObjectRepository;
        
        private IMapperProvider _mapperProvider;

        public SectionService(SectionRepositopy sectionRepositopy, IMapperProvider mapperProvider)
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
                var mainSection = await _sectionRepositopy.GetItemAsync(id);
                var result = await _sectionRepositopy.GetListAsync(x => x.ParentId == id);
                var typeObject = await _typeObjectRepositopy.GetListAsync(x => x.Section.Id == id);
                
                return Result.Ok(sectionDtos);
            }
            catch (Exception ex)
            {
                return Result.Fail("При получении списка разделов произошла ошибка.");
            }
        }
    }
}