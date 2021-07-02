using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using WebApiHandlers.Interfaces;

namespace Vega.Controllers
{
    [Authorize(Roles = "Administrator,Expert,User")]
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
