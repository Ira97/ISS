using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApiHandlers.Interfaces;

namespace WebApiHandlers.Providers
{
    
    public class AreaProvider : IAreaProvider
    {
        private readonly IWebHttpClientProvider _httpClientProvider;

        public AreaProvider(IWebHttpClientProvider httpClientProvider)
        {
            _httpClientProvider = httpClientProvider;
        }

        public Task CreateAreaAsync(AreaDto areaDto)
        {
            throw new NotImplementedException();
        }

        public async Task<AreaDto> GetAreaAsync(int id)
        {
            return await _httpClientProvider.SendHttpGetRequest<AreaDto>($"area/{id}");
        }

        public async Task<List<AreaDto>> GetAreaListAsync()
        {
            return await _httpClientProvider.SendHttpGetRequest<List<AreaDto>>("area/list");
        }
    }
}
