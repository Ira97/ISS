using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.ViewModels;
using WebApiHandlers.Interfaces;

namespace Vega.Controllers
{
    public class TypeObjectController : Controller
    {

        private readonly ISectionProvider _sectionProvider;

        public TypeObjectController(ISectionProvider sectionProvider)
        {
            _sectionProvider = sectionProvider;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> New(int sectionId)
        {
            var model = new TypeObjectDto { SectionId = sectionId};
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> New(TypeObjectDto typeObject)
        {
            await _sectionProvider.CreateTypeObjectAsync(typeObject);
            return RedirectToAction("View","Section", typeObject.SectionId); ;
        }
    }
}
