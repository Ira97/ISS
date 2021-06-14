using Microsoft.AspNetCore.Mvc;
using Models.Search;
using System.Threading.Tasks;
using WebApiHandlers.Interfaces;

namespace Vega.Controllers
{
    public class SearchController : Controller
    {
        private readonly ISearchProvider _searchProvider;
        private readonly ISectionProvider _sectionProvider;

        public SearchController(ISearchProvider searchProvider, ISectionProvider sectionProvider)
        {
            _searchProvider = searchProvider;
            _sectionProvider = sectionProvider;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string value)
        {
            var searchResult = await _searchProvider.GetSimpleSearchResult(value);
            searchResult.SectionList = await _sectionProvider.GetSectionListAsync();
            searchResult.DataObjectList = await _sectionProvider.GetObjectListAsync();
            searchResult.MethodList = await _sectionProvider.GetMethodListAsync();
            searchResult.ThingList = await _sectionProvider.GetObjectListAsync();
            searchResult.PropertyList = await _sectionProvider.GetPropertyListAsync();
            searchResult.Value = value;
            return View(searchResult);
        }

        [HttpPost]
        public async Task<IActionResult> Index(SearchRequest searchRequest)
        {
            return View();
        }
    }
}
