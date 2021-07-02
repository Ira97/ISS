using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.ViewModels;
using System.Threading.Tasks;
using WebApiHandlers.Interfaces;

namespace Vega.Controllers
{
    [Authorize(Roles = "Administrator,Expert,User")]
    public class SectionController : Controller
    {
        private readonly ISectionProvider _sectionProvider;

        public SectionController(ISectionProvider sectionProvider)
        {
            _sectionProvider = sectionProvider;
        }

   

        [HttpGet]
        public async Task<IActionResult> View(int id)
        {
            var model = await _sectionProvider.GetSectionAsync(id);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> New(int parentId)
        {
            var sectionViewModel = new SectionViewModel
            {
                ParentId = parentId,
                Section = new Models.SectionDto()
            };
            return View(sectionViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> New(Models.SectionDto section)
        {
            await _sectionProvider.CreateSectionAsync(section);
            return RedirectToAction("View", section.ParentId);
        }
    }
}
