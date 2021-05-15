using System;
using BusinessLogicCore.Interfaces;
using FluentResults;
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

        public Result CreateAreaAsync(AreaDto area)
        {
            try
            {
                var area =_mapperProvider.CreateMapByProfile<,Area>()
                Result.Ok();
            }
            catch (Exception e)
            {
               Result.Fail("sdjhfgdhsjfghjgs")
            }
            
        }

    }
}