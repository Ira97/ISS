using Models.Search;
using System;
using System.Threading.Tasks;
using WebApiHandlers.Interfaces;

namespace WebApiHandlers.Providers
{
    public class SearchProvider : ISearchProvider
    {
        private readonly IWebHttpClientProvider _httpClientProvider;

        public SearchProvider(IWebHttpClientProvider httpClientProvider)
        {
            _httpClientProvider = httpClientProvider;
        }

        public async Task<SearchResult> GetSearchResult(SearchResult searchRequest)
        {
            return await _httpClientProvider.SendHttpPostWithResponse<SearchResult>(searchRequest, "search");
        }

        public async Task<SimpleSearchResult> GetSimpleSearchResult(string value)
        {
            return await _httpClientProvider.SendHttpGetRequest<SimpleSearchResult>($"search/simple?value={value}");
        }
    }
}
