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
        public List<TypeObjectDto> TypeObjectDtos { set; get; }

        public MainSectionDto()
        {
            SectionDtos = new List<SectionDto>();
            TypeObjectDtos = new List<TypeObjectDto>();
        }

    }
}