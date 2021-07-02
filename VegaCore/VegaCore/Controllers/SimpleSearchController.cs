using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiHandlers.Interfaces;

namespace Vega.Controllers
{
    [Authorize(Roles = "Administrator,Expert,User")]
    public class SimpleSearchController : Controller
    {
        private readonly ISearchProvider _searchProvider;

        public SimpleSearchController(ISearchProvider searchProvider)
        {
            _searchProvider = searchProvider;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string value)
        {
            var searchResult = await _searchProvider.GetSimpleSearchResult(value);
            searchResult.Value = value;
            return View(searchResult);
        }
    }
}
