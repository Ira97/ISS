using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vega.Controllers
{
    public class SectionController : Controller
    {
        public SectionController()
        {

        }

        [HttpGet]
        public async Task<IActionResult> View()
        {
            var model = new SectionDto();
            return View(model);
        }
    }
}
