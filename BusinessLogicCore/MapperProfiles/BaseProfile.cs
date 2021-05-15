using AutoMapper;
using Models;
using ScientificDatabase.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicCore.MapperProfiles
{
    /// <summary>
    /// Профиль автомаппера 
    /// </summary>
    public class BaseProfile : Profile
    {
        public BaseProfile()
        {
            CreateMap<ScientificDatabase.Models.User, Models.User>();
            CreateMap<ScientificDatabase.Models.UserRole, Models.UserRole>();
        }
    }
}
