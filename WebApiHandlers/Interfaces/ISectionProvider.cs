using Models;
using ScientificDatabase.Models.TypeObject;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WebApiHandlers.Interfaces
{
    public interface ISectionProvider
    {
        Task<MainSectionDto> GetSectionAsync(int id);
        Task<List<SectionDto>> GetSectionListAsync();
        Task<List<DataObjectDto>> GetObjectListAsync();
        Task<List<MethodDto>> GetMethodListAsync();
        Task<List<PropertyDto>> GetPropertyListAsync();
        Task CreateSectionAsync(SectionDto section);
        Task CreateTypeObjectAsync(TypeObjectDto typeObject);
        Task CreateDataObjectAsync(DataObjectDto dataObject);
        Task<List<ContactTypeDto>> GetContactListAsync();
        Task<TypeObjectDto> GetTypeObject(int typeObjectId);
    }
}
