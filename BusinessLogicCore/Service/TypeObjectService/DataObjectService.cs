using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogicCore.Interfaces;
using BusinessLogicCore.Service.TypeObjectService;
using Models;
using ScientificDatabase.Models.TypeObject;
using ScientificDatabase.Repositories;
using ScientificDatabase.Repositories.TypeObjectRepositopy;

namespace BusinessLogicCore.Service.TypeObject
{
    public class DataObjectService : IDataObjectService
    {
        private readonly DataObjectRepository _dataObjectRepository;
        private readonly IMapperProvider _mapperProvider;

        public DataObjectService(IMapperProvider mapperProvider, DataObjectRepository dataObjectRepository)
        {
            _mapperProvider = mapperProvider;
            _dataObjectRepository = dataObjectRepository;
        }

        public async Task<List<DataObjectDto>> GetDataObjectAsync()
        {
            var dataObjectList = await _dataObjectRepository.GetItemsAsync();
            var mapped = _mapperProvider.CreateMapForList<DataObject, DataObjectDto>(dataObjectList);
            return mapped;
        }
    }
}