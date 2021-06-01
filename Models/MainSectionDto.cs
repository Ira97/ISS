﻿
using System.Collections.Generic;

namespace Models
{
    public class MainSectionDto
    {
        public int Id { get; set; }
        public string Name { set; get; }
        public int ParentId { set; get;}
        public int AresId { set; get;}
        public List<SectionDto> SectionDtos { set; get; }
        public List<TypeObjectDto> TypeObjects { set; get; }
        public List<ResearchDto> Researches { get; set; }

        public MainSectionDto()
        {
            SectionDtos = new List<SectionDto>();
            TypeObjects = new List<TypeObjectDto>();
        }

    }
}