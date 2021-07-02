﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Search;
using System.Threading.Tasks;

using WebApiHandlers.Interfaces;

namespace Vega.Controllers
{
    [Authorize(Roles = "Administrator,Expert,User")]
    public class SearchController : Controller
    {
        private readonly ISearchProvider _searchProvider;

        public SearchController(ISearchProvider searchProvider, ISectionProvider sectionProvider)
        {
            _searchProvider = searchProvider;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(new SearchResult());
        }

        [HttpPost]
        public async Task<IActionResult> Index(SearchResult searchResult)
        {
            searchResult = await _searchProvider.GetSearchResult(searchResult);
            return View(searchResult);
        }
    }
}
