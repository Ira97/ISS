using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogicCore.Interfaces;
using BusinessLogicCore.MapperProfiles;
using FluentResults;
using Models;
using ScientificDatabase.Models.Hierarchy;
using ScientificDatabase.Repositories;

namespace BusinessLogicCore.Service
{
    public class AreaService
    {
        private AreaRepository _areaRepository;
        private IMapperProvider _mapperProvider;

        public AreaService(AreaRepository areaRepository, IMapperProvider mapperProvider)
        {
            _areaRepository = areaRepository;
            _mapperProvider = mapperProvider;
        }

        public async Task<Result> CreateAreaAsync(AreaDto areaDto)
        {
            try
            {
                var area = _mapperProvider.CreateMapByProfile<AreaDto, Area, BaseProfile>(areaDto);
                await _areaRepository.InsertItemAsync(area);
                return Result.Ok();
            }
            catch (Exception ex)
            {
                return Result.Fail("При создании области науки возникла ошибка.");
            }
        }
        
        public async Task<Result<List<AreaDto>>> GetAreaAsync()
        {
            try
            {
                var result = await _areaRepository.GetItemsAsync();
                var areas = _mapperProvider.CreateMapForList<Area, AreaDto>(result);
                return Result.Ok(areas);
            }
            catch (Exception ex)
            {
                return Result.Fail("Не удалось получить данные об областях науки.");
            }
        }
        public async Task<Result<AreaDto>> GetSectionsForAreaAsync(int areaId)
        {
            try
            {
                var result =  await _areaRepository.GetSectionAsync(areaId);
                var areaDto = _mapperProvider.CreateMapByProfile<Area, AreaDto, BaseProfile>(result);
                return Result.Ok(areaDto);
            }
            catch (Exception ex)
            {
                return Result.Fail("Не удалось получить данные об областях науки.");
            }
        }
    }
}