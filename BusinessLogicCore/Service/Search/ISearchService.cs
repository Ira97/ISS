using FluentResults;
using Models.Search;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicCore.Service.Search
{
    public interface ISearchService
    {
        Task<Result<SimpleSearchResult>> GetSimpleSearchAsync(string value);
        Task<Result<SearchResult>> GetSearchAsync(SearchResult searchResult);
    }
}
