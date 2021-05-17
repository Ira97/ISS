using System.Collections.Generic;
using BusinessLogicCore.Interfaces;
using ScientificDatabase.Repositories.TypeObjectRepositopy;

namespace BusinessLogicCore.Service.TypeObject
{
    public class DataObjectService
    {
        private readonly  DataObjectRepository _dataObjectRepository;
        private readonly IMapperProvider _mapperProvider;

        public DataObjectService(DataObjectRepository dataObjectRepository, IMapperProvider mapperProvider)
        {
            _dataObjectRepository = dataObjectRepository;
            _mapperProvider = mapperProvider;
        }

        //public List<> GetDataObjectAsync()
        //{
            
        //}
    }
}