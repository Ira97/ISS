using System;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Models.Setting;
using Newtonsoft.Json;
using WebApiHandlers.Interfaces;

namespace WebApiHandlers.Providers
{
    /// <inheritdoc cref="IWebHttpClientProvider"/>>
    public class WebHttpClientProvider : BaseProvider , IWebHttpClientProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAccessTokenProvider _accessTokenProvider;

        /// <summary>
        /// Инициализирует экземпляр <see cref="WebHttpClientProvider"/>
        /// </summary>
        /// <param name="appSettings"></param>
        /// <param name="logger"></param>
        /// <param name="httpContextAccessor"></param>
        /// <param name="accessTokenProvider"></param>
        
        public WebHttpClientProvider(IOptions<AppSettings> appSettings, ILogger<WebHttpClientProvider> logger,
            IHttpContextAccessor httpContextAccessor, IAccessTokenProvider accessTokenProvider) : base(appSettings, logger)
        {
            _httpContextAccessor = httpContextAccessor;
            _accessTokenProvider = accessTokenProvider;
        }

        /// <inheritdoc/>
        public async Task<T> SendHttpDeleteRequest<T>(string url) where T : new()
        {
            try
            {
                using var httpClient = new HttpClient();
                var response = await httpClient.DeleteAsync($"{AppSettings.WebApiServer}{url}");
                if (response.IsSuccessStatusCode)
                {
                    response.EnsureSuccessStatusCode();
                    var responseBody = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<T>(responseBody);
                    return result;
                }
                Logger.LogDebug(response.RequestMessage.ToString());
                return new T();
            }
            catch (Exception exception)
            {
                Logger.LogError(exception, $"SendHttpGetRequest {url}");
                return new T();
            }
        }

        /// <inheritdoc/>
        public async Task<T> SendHttpGetRequest<T>(string url) where T : class
        {
            try
            {
                using var httpClient = new HttpClient();
                httpClient.Timeout = TimeSpan.FromMinutes(40);
                var response =
                    await httpClient.GetAsync($"{AppSettings.WebApiServer}{url}");
                var responseBody = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode) throw new Exception(responseBody);
                response.EnsureSuccessStatusCode();
                var result = JsonConvert.DeserializeObject<T>(responseBody);
                return result;
            }
            catch (Exception exception)
            {
                Logger.LogError(exception, $"SendHttpGetRequest {url}");
                throw new Exception(exception.Message);
            }
        }

        /// <inheritdoc/>
        public async Task<bool> SendHttpPostRequest(object data, string url)
        {
            try
            {
                using var httpClient = new HttpClient();
  
                using HttpContent httpContent = new ObjectContent(typeof(object), data,
                    new JsonMediaTypeFormatter());
                var response =
                    await httpClient.PostAsync($"{AppSettings.WebApiServer}{url}", httpContent);
                if (response.IsSuccessStatusCode)
                {
                    response.EnsureSuccessStatusCode();
                    return true;
                }
            }
            catch (Exception exception)
            {
                Logger.LogError(exception, $"Ошибка при выполнении Post запроса {url}. {data}");
            }
            return false;
        }

        /// <inheritdoc/>
        public async Task<T> SendHttpPostWithResponse<T>(object data, string url) where T : new()
        {
            try
            {
                using var httpClient = new HttpClient();
       
                using HttpContent httpContent = new ObjectContent(typeof(object), data,
                    new JsonMediaTypeFormatter());
                var response =
                    await httpClient.PostAsync($"{AppSettings.WebApiServer}{url}", httpContent);
                var responseBody = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    response.EnsureSuccessStatusCode();
                    var result = JsonConvert.DeserializeObject<T>(responseBody);
                    return result;
                }
            }
            catch (Exception exception)
            {
                Logger.LogError(exception, $"Ошибка при выполнении Post запроса {url}. {data}");
            }
            return new T();
        }

        /// <inheritdoc/>
        public async Task<long> SendHttpPutRequest(object data, string url)
        {
            try
            {
                using var httpClient = new HttpClient();
               
                using HttpContent httpContent = new ObjectContent(typeof(object), data,
                    new JsonMediaTypeFormatter());
                var response =
                    await httpClient.PutAsync($"{AppSettings.WebApiServer}{url}", httpContent);
                var responseBody = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode) throw new Exception(responseBody);
                response.EnsureSuccessStatusCode();
                var result = JsonConvert.DeserializeObject<long>(responseBody);
                return result;
            }
            catch (Exception exception)
            {
                Logger.LogError(exception, $"Ошибка при выполнении Update запроса {url}. {data}");
                throw new Exception(exception.Message);
            }
        }


     

        
    }
}
