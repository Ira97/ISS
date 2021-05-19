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
            var model = new MainSectionDto
            {
                Name = "Такая то химия",
                SectionDtos = new List<SectionDto>
                {
                    new SectionDto
                    {
                        Id = 0,
                        Name = "Поддотдел",
                        Description = "Donec id elit non mi porta gravida at eget metus. Maecenas sed diam eget risus varius blandit.",
                        UpdateDateTime = DateTime.Now.AddDays(-5)
                    },
                    new SectionDto
                    {
                        Id = 1,
                        Name = "Поддотдел1",
                        Description = "Donec id elit non mi porta gravida at eget metus. Maecenas sed diam eget risus varius blandit.",
                        UpdateDateTime = DateTime.Now.AddDays(-15)
                    },
                    new SectionDto
                    {
                        Id = 2,
                        Name = "Поддотдел2",
                        Description = "Donec id elit non mi porta gravida at eget metus. Maecenas sed diam eget risus varius blandit.",
                        UpdateDateTime = DateTime.Now.AddDays(-3)
                    },
                    new SectionDto
                    {
                        Id = 3,
                        Name = "Поддотдел3",
                        Description = "Donec id elit non mi porta gravida at eget metus. Maecenas sed diam eget risus varius blandit.",
                        UpdateDateTime = DateTime.Now.AddDays(-1)
                    },
                },
                DataObjectDtos = new List<DataObjectDto>
                {
                    new DataObjectDto
                    {
                        Id = 23,
                        Name = "Водород",
                        ValuePropertyObjectDtos = new List<ValuePropertyObjectDto>
                        {
                            new ValuePropertyObjectDto
                            {
                                 Value = "H",
                                 Property = new PropertyDto
                                 {
                                     Name = "Символ"
                                 }
                            },
                             new ValuePropertyObjectDto
                            {
                                 Value = "Hydrogenium",
                                 Property = new PropertyDto
                                 {
                                     Name = "Латинское название"
                                 }
                            },
                            new ValuePropertyObjectDto
                            {
                                 Value = "1, 1",
                                 Property = new PropertyDto
                                 {
                                     Name = "Период, группа"
                                 }
                            },
                            new ValuePropertyObjectDto
                            {
                                 Value = "1,00794",
                                 Property = new PropertyDto
                                 {
                                     Name = "Атомная масса"
                                 }
                            },
                            new ValuePropertyObjectDto
                            {
                                 Value = "0,08988 г/л",
                                 Property = new PropertyDto
                                 {
                                     Name = "Плотность"
                                 }
                            },
                            new ValuePropertyObjectDto
                            {
                                 Value = "1766",
                                 Property = new PropertyDto
                                 {
                                     Name = "Год открытия"
                                 }
                            },
                            new ValuePropertyObjectDto
                            {
                                 Value = "Кавердиш",
                                 Property = new PropertyDto
                                 {
                                     Name = "Первооткрыватель"
                                 }
                            },
                        }
                    },
                    new DataObjectDto
                    {
                        Id = 17,
                        Name = "Гелий",
                          ValuePropertyObjectDtos = new List<ValuePropertyObjectDto>
                        {
                            new ValuePropertyObjectDto
                            {
                                 Property = new PropertyDto
                                {

                                }
                            }

                        }
                    },
                     new DataObjectDto
                    {
                        Id = 51,
                        Name = "Кислород",
                          ValuePropertyObjectDtos = new List<ValuePropertyObjectDto>
                        {
                            new ValuePropertyObjectDto
                            {
                                 Property = new PropertyDto
                                {

                                }
                            }

                        }
                    },
                }
            };
            return View(model);
        }
    }
}
