using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Search;
using System.Collections.Generic;
using System.Threading.Tasks;

using WebApiHandlers.Interfaces;

namespace Vega.Controllers
{
    [Authorize(Roles = "Administrator,Expert,User")]
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
        public async Task<IActionResult> Index()
        {
            var searchResult = new SearchResult()
            {
                SectionList = await _sectionProvider.GetSectionListAsync(),
                ContactList = await _sectionProvider.GetContactListAsync(),
                SecondContactList = await _sectionProvider.GetContactListAsync(),
                MethodList = await _sectionProvider.GetMethodListAsync()
            };
            return View(searchResult);
        }

        [HttpPost]
        public async Task<IActionResult> Index(SearchResult searchResult)
        {
            searchResult = await _searchProvider.GetSearchResult(searchResult);
            searchResult.SecondEntryList = new List<Entry> 
            {
                new Entry()
                {
                    Type = "Research",
                    Name = "Исследование поведения водорода в процессах производства конструкционных сталей"
                },
                new Entry()
                {
                    Type = "Research",
                    Name = "Исследование влияния атомарного водорода на поликристаллические тонкие пленки полупроводников"
                },
            };
            searchResult.SecondEntryList.AddRange(searchResult.EntryList);
            searchResult.ThirdEntryList = new List<Entry>
            {
                new Entry()
                {
                    Type = "Research",
                    Name = "Исследование поведения водорода в процессах производства конструкционных сталей"
                },
                new Entry()
                {
                    Type = "Research",
                    Name = "Исследование влияния атомарного водорода на поликристаллические тонкие пленки полупроводников"
                },
            };     
            searchResult.SectionList = await _sectionProvider.GetSectionListAsync();
            searchResult.ContactList = await _sectionProvider.GetContactListAsync();
            searchResult.SecondContactList = await _sectionProvider.GetContactListAsync();
            searchResult.MethodList = await _sectionProvider.GetMethodListAsync();
            return View(searchResult);
        }
    }
}
