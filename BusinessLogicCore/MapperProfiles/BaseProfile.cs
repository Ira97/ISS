using AutoMapper;
using ScientificDatabase.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Models;
using Models.User;
using ScientificDatabase.Models.Hierarchy;
using ScientificDatabase.Models.TypeObject;

namespace BusinessLogicCore.MapperProfiles
{
    /// <summary>
    /// Профиль автомаппера 
    /// </summary>
    public class BaseProfile : Profile
    {
        public BaseProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<AreaDto, Area>();
            CreateMap<Area, AreaDto>();
            CreateMap<SectionDto, Section>();
            CreateMap<Section, SectionDto>();
            CreateMap<TypeObjectDto, TypeObject>();
            CreateMap<TypeObject, TypeObjectDto>();
            CreateMap<MainSectionDto, Section>();
            CreateMap<Section, MainSectionDto>(); 
            CreateMap<Role, RoleDto>();
            CreateMap<DataObject, DataObjectDto>();
            CreateMap<Property, PropertyDto>();
            CreateMap<ValuePropertyObject, ValuePropertyObjectDto>();
            CreateMap<Research, ResearchDto>();

        }
    }
}
