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

        public Task<SearchResult> GetFullSearchResult(SearchRequest searchRequest)
        {
            throw new NotImplementedException();
        }

        public async Task<SearchResult> GetSimpleSearchResult(string value)
        {
            return await _httpClientProvider.SendHttpGetRequest<SearchResult>($"search/simple?value={value}");
        }
    }
}
