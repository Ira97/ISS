using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.ViewModels;

namespace Vega.Controllers
{
    [Authorize(Roles = "Administrator,Expert,User")]
    public class ResearchController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult View([FromQuery]int sectionId)
        {
            var researchViewModel = new ResearchViewModel()
            {
                SectionId = sectionId,
                Research = new ResearchDto(),
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
    }
}
