using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApiHandlers.Interfaces;

namespace WebApiHandlers.Providers
{
    public class SectionProvider : ISectionProvider
    {
        private readonly IWebHttpClientProvider _httpClientProvider;

        public SectionProvider(IWebHttpClientProvider httpClientProvider)
        {
            _httpClientProvider = httpClientProvider;
        }

        public async Task<MainSectionDto> GetSectionAsync(int id)
        {
            return await _httpClientProvider.SendHttpGetRequest<MainSectionDto>($"section/{id}");
        }

      
    }
}
