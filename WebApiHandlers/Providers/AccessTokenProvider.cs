using System;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using IdentityServer4.Stores.Serialization;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Models;
using Models.Security;
using Models.Setting;
using Newtonsoft.Json;
using WebApiHandlers.Interfaces;

namespace WebApiHandlers.Providers
{
    /// <inheritdoc cref="IAccessTokenProvider"/>/>
    public class AccessTokenProvider : BaseProvider, IAccessTokenProvider
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="AccessTokenProvider"/>
        /// </summary>
        /// <param name="appSettings"></param>
        /// <param name="logger"></param>
        public AccessTokenProvider(IOptions<AppSettings> appSettings, ILogger<WebHttpClientProvider> logger) : base(appSettings, logger)
        {
        }
    

        /// <summary>
        /// Получение Токена
        /// </summary>
        /// <returns></returns>
        public async Task<ApplicationUser> GetApplicationUserAsync(string userName, string password)
        {
            try
            {
                return new ApplicationUser();
            }
            catch (Exception exception)
            {
                Logger.LogError(exception, "Ошибка при получении токена.");
                return null;
            }
        }

      

    }
}
