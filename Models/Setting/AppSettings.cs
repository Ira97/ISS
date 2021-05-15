namespace Models.Setting
{
    /// <summary>
    /// Настройки приложения
    /// </summary>
    public class AppSettings
    {
        /// <summary>
        /// Адрес WebApi
        /// </summary>
        public string WebApiServer { get; set; }
        /// <summary>
        /// Сервер авторизации
        /// </summary>
        public string AuthServer { get; set; }
        /// <summary>
        /// Удалённое расположение приложений
        /// </summary>
        public string RemoteAppPath { get; set; }
        /// <summary>
        /// Локальное расположение приложений
        /// </summary>
        public string LocalAppPath { get; set; }
        public string CrmFolder { get; set; }
        public string CrmFileName { get; set; }
        public string RemoteAdvancePath { get; set; }
        /// <summary>
        /// Токен бота для экспедиторов
        /// </summary>
        public string ExpeditorBotToken { get; set; }
        /// <summary>
        /// Токен бота для hr
        /// </summary>
        public string HRBotToken { get; set; }
    }
}
