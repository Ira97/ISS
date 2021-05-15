using System;
using System.IO;
using Newtonsoft.Json;

namespace WebApiHandlers.Settings
{
    /// <summary>
    /// Менеджер настроек
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SettingsManager<T> where T : class
    {
        private readonly string filePath;
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="fileName"></param>
        public SettingsManager(string fileName)
        {
            filePath = GetLocalFilePath(fileName);
        }

        /// <summary>
        /// Получение пути к файлу
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private string GetLocalFilePath(string fileName)
        {
            var appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            return Path.Combine(appData, fileName);
        }

        /// <summary>
        /// Загрузка настроек
        /// </summary>
        /// <returns></returns>
        public T LoadSettings() =>
            File.Exists(filePath) ?
                JsonConvert.DeserializeObject<T>(File.ReadAllText(filePath)) : null;
        /// <summary>
        /// Сохранение настроек
        /// </summary>
        /// <param name="settings"></param>
        public void SaveSettings(T settings)
        {
            var json = JsonConvert.SerializeObject(settings);
            File.WriteAllText(filePath, json);
        }
    }
}
