using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApiHandlers.Interfaces;

namespace Vega.Controllers
{
    public class SearchController : Controller
    {
        private readonly ISearchProvider _searchProvider;

        public SearchController(ISearchProvider searchProvider)
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

        [HttpPost]
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
