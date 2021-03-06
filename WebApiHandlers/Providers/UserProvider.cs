using System;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using IdentityServer4.Stores.Serialization;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Models.Security;
using Models.Setting;
using Models.User;
using Models.ViewModels;
using Newtonsoft.Json;
using WebApiHandlers.Interfaces;

namespace WebApiHandlers.Providers
{
    /// <inheritdoc cref="IUserProvider"/>/>
    public class UserProvider : BaseProvider, IUserProvider
    {
        private readonly IWebHttpClientProvider _httpClientProvider;
        /// <summary>
        /// Инициализирует экземпляр <see cref="UserProvider"/>
        /// </summary>
        /// <param name="appSettings"></param>
        /// <param name="logger"></param>
        public UserProvider(IOptions<AppSettings> appSettings, ILogger<WebHttpClientProvider> logger, IWebHttpClientProvider httpClientProvider) : base(appSettings, logger)
        {
            _httpClientProvider = httpClientProvider;
        }


        /// <summary>
        /// Получение Токена
        /// </summary>
        /// <returns></returns>
        public async Task<ApplicationUser> GetApplicationUserAsync(string userName, string password)
        {
            try
            {
                var validateUser = new ValidateUserDto
                {
                    Login = userName,
                    Password = password
                };
                var user = await _httpClientProvider.SendHttpPostWithResponse<User>(validateUser, "user/validate");
                return new ApplicationUser();
            }
            catch (Exception exception)
            {
                Logger.LogError(exception, "Ошибка при получении данных .");
                return null;
            }
        }

        public async Task RegisterUserAsync(RegisterViewModel model)
        {
            await _httpClientProvider.SendHttpPostRequest(model, "user/register");
        }
    }
}
