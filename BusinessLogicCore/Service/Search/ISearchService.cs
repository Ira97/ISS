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
        Task<Result<SearchResult>> GetSimpleSearchAsync(string value);
    }
}
