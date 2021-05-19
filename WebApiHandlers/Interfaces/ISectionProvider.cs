using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WebApiHandlers.Interfaces
{
    public interface ISectionProvider
    {
        Task<MainSectionDto> GetSectionAsync(int id);
    }
}
