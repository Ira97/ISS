using System.Collections.Generic;
using BusinessLogicCore.Interfaces;
using ScientificDatabase.Repositories;
using ScientificDatabase.Repositories.TypeObjectRepositopy;

namespace BusinessLogicCore.Service.TypeObject
{
    public class DataObjectService
    {
        private readonly  ResearchRepository _dataObjectRepository;
        private readonly IMapperProvider _mapperProvider;

        public DataObjectService(ResearchRepository dataObjectRepository, IMapperProvider mapperProvider)
        {
            _dataObjectRepository = dataObjectRepository;
            _mapperProvider = mapperProvider;
        }

        //public List<> GetDataObjectAsync()
        //{
            
        //}
    }
}