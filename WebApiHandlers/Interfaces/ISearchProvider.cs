using Models.Search;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WebApiHandlers.Interfaces
{
    public interface ISearchProvider
    {
        Task<SearchResult> GetSimpleSearchResult(string value);
        Task<SearchResult> GetFullSearchResult(SearchRequest searchRequest);
    }
}
