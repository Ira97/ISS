using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.ViewModels;
using WebApiHandlers.Interfaces;

namespace Vega.Controllers
{
    [Authorize(Roles = "Administrator,Expert,User")]
    public class AreaController : Controller
    {
        private readonly IAreaProvider _areaProvider;

        public AreaController(IAreaProvider areaProvider)
        {
            _areaProvider = areaProvider;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = new AreaViewModel()
            {
                AreaList = await _areaProvider.GetAreaListAsync()
            };
            return View(model);
        }


        public async Task<IActionResult> View(int id)
        {
            var model = await _areaProvider.GetAreaAsync(id);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> New()
        {
            var model = new AreaDto();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> New(AreaDto area)
        {
            await _areaProvider.CreateAreaAsync(area);
            return RedirectToAction("index");
        }
    }
}
