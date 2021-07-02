using System;
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
    public class DataObjectController : Controller
    {

        private readonly ISectionProvider _sectionProvider;

        public DataObjectController(ISectionProvider sectionProvider)
        {
            _sectionProvider = sectionProvider;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> New(int typeObjectId)
        {

            var model = new DataObjectDto { TypeObjectId = typeObjectId};
            model.TypeObject = await _sectionProvider.GetTypeObject(typeObjectId);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> New(DataObjectDto dataObject)
        {
            await _sectionProvider.CreateDataObjectAsync(dataObject);
            return RedirectToAction("View","Section");
        }
    }
}
