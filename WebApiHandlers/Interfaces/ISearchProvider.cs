using Models.Search;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WebApiHandlers.Interfaces
{
    public interface ISearchProvider
    {
        Task<SimpleSearchResult> GetSimpleSearchResult(string value);
        Task<SearchResult> GetSearchResult(SearchResult searchRequest);
    }
}
