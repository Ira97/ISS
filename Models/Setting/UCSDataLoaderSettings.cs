using System;

namespace Models.Setting
{
    /// <summary>
    /// Настройки приложения
    /// </summary>
    public class UCSDataLoaderSettings
    {
        /// <summary>
        /// Количество дней от текущего для загрузки
        /// </summary>
        public int CountOfDaysToSave { get; set; }
        /// <summary>
        /// Путь сохранения результата
        /// </summary>
        public string PathToSave { get; set; }

        /// <summary>
        /// Запрос
        /// </summary>
        public string Query { get; set; }

        /// <summary>
        /// Начальная дата, если не задана, то текущее
        /// </summary>
        public DateTime? StartDate { get; set; }
    }
}
