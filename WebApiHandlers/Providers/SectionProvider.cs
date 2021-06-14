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

        public async Task<List<DataObjectDto>> GetObjectListAsync()
        {
            return await _httpClientProvider.SendHttpGetRequest<List<DataObjectDto>>($"section/object");
        }

        public async Task<List<MethodDto>> GetMethodListAsync()
        {
            return await _httpClientProvider.SendHttpGetRequest<List<MethodDto>>($"section/method");
        }

        public async Task<List<PropertyDto>> GetPropertyListAsync()
        {
            return await _httpClientProvider.SendHttpGetRequest<List<PropertyDto>>($"section/property");
        }
        public async Task<List<SectionDto>> GetSectionListAsync()
        {
            return await _httpClientProvider.SendHttpGetRequest<List<SectionDto>>($"section/list");
        }

        public async Task CreateSectionAsync(SectionDto section)
        {
            await _httpClientProvider.SendHttpPostRequest(section, $"section");
        }

        public async Task CreateResearchAsync(ResearchDto research)
        {
            await _httpClientProvider.SendHttpPostRequest(research, $"section/research");
        }

        public async Task CreateDataObjectAsync(DataObjectDto dataObject)
        {
            await _httpClientProvider.SendHttpPostRequest(dataObject, $"section/object");
        }

        public Task CreateTypeObjectAsync(TypeObjectDto typeObject)
        {
            throw new NotImplementedException();
        }
    }
}
