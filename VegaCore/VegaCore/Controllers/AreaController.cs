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
            var model = await _areaProvider.GetAreaListAsync();
            //var model = new AreaViewModel()
            //{
            //    AreaList = new List<AreaDto>
            //    {
            //        new AreaDto
            //        {
            //            Id =1,
            //            Name = "Химия",
            //            ImageName = "Chemistry-bg.jpg"
            //        },
            //        new AreaDto
            //        {
            //            Id =2,
            //            Name = "Физика"
            //        },
            //        new AreaDto
            //        {
            //            Id =3,
            //            Name = "Биология"
            //        },
            //        new AreaDto
            //        {
            //            Id =4,
            //            Name = "Литра"
            //        },
            //        new AreaDto
            //        {
            //            Id =5,
            //            Name = "Труды"
            //        },
            //    }
            //};
            return View(model);
        }

       
        public async Task<IActionResult> View(int id)
        {
            var model = await _areaProvider.GetAreaAsync(id);
            //var model = new AreaDto()
            //{
            //    Id = id,
            //    Name = "Химия",
            //    Section = new List<SectionDto>
            //    {
            //        new SectionDto()
            //        {
            //            Id = 1,
            //            Name = "Такая химия"
            //        },
            //        new SectionDto()
            //        {
            //            Id = 2,
            //            Name = "Другая химия"
            //        },
            //         new SectionDto()
            //        {
            //            Id = 3,
            //            Name = "Третья химия"
            //        },
            //          new SectionDto()
            //        {
            //            Id = 4,
            //            Name = "Четвертая химия"
            //        },
            //           new SectionDto()
            //        {
            //            Id = 5,
            //            Name = "Пятая химия"
            //        },
            //              new SectionDto()
            //        {
            //            Id = 6,
            //            Name = "Шестая химия"
            //        },
            //           new SectionDto()
            //        {
            //            Id = 7,
            //            Name = "Седьмая химия"
            //        }
            //    }
            //};
            return View(model);
        }
    }
}
