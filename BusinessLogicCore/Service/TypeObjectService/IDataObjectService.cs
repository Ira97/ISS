using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicCore.Service.TypeObjectService
{
    interface IDataObjectService
    {
        Task<List<DataObjectDto>> GetDataObjectAsync();
    }
}
