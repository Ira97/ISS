using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.ViewModels;
using WebApiHandlers.Interfaces;

namespace Vega.Controllers
{
    [Authorize(Roles = "Administrator,Expert,User")]
    public class ResearchController : Controller
    {
        private readonly ISectionProvider _sectionProvider;

        public ResearchController(ISectionProvider sectionProvider)
        {
            _sectionProvider = sectionProvider;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> NewAsync([FromRoute] int? id, [FromQuery]int sectionId)
        {
            var section = await _sectionProvider.GetSectionAsync(sectionId);
            var researchViewModel = new ResearchViewModel()
            {
                SectionId = sectionId,
                Research = id == null ? new ResearchDto() : section.Researches.FirstOrDefault(x => x.Id == id),
                DataObjectList = new List<DataObjectDto>
                {
                    new DataObjectDto
                    {
                        Id = 0, Name = "Водород"
                    },
                     new DataObjectDto
                    {
                        Id = 1, Name = "Гелий"
                    }
                }
            };
            return View(researchViewModel);
        }

        public async Task<IActionResult> View([FromRoute] int id, [FromQuery] int sectionId)
        {
            var section = await _sectionProvider.GetSectionAsync(sectionId);
            var researchViewModel = new ResearchViewModel()
            {
                Research = section.Researches.FirstOrDefault(x => x.Id == id)
            };
            researchViewModel.Research.DataObjects = new List<DataObjectDto>
                {
                    new DataObjectDto
                    {
                        Id = 0, Name = "Водород"
                    },
                     new DataObjectDto
                    {
                        Id = 1, Name = "Гелий"
                    }
                };
            return View(researchViewModel);
        }
    }
}
