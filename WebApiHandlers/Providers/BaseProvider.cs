using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Models.Setting;

namespace WebApiHandlers.Providers
{
    /// <summary>
    /// Базовый провайдер
    /// </summary>
    public class BaseProvider
    {
        /// <summary>
        /// Логгер
        /// </summary>
        protected readonly ILogger Logger;
        /// <summary>
        /// Настройки
        /// </summary>
        protected readonly AppSettings AppSettings;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="appSettings"></param>
        /// <param name="logger"></param>
        protected BaseProvider(IOptions<AppSettings> appSettings, ILogger logger)
        {
            AppSettings = appSettings.Value;
            Logger = logger;
        }
    }
}
