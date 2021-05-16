using AutoMapper;
using ScientificDatabase.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Models;
using ScientificDatabase.Models.Hierarchy;

namespace BusinessLogicCore.MapperProfiles
{
    /// <summary>
    /// Профиль автомаппера 
    /// </summary>
    public class BaseProfile : Profile
    {
        public BaseProfile()
        {
            CreateMap<ScientificDatabase.Models.User, Models.User.User>();
            CreateMap<AreaDto, Area>();
        }
    }
}
