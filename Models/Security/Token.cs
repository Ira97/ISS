using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Security
{
    /// <summary>
    /// Токен
    /// </summary>
    public class Token
    {
        /// <summary>
        /// Значение
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// Идентификатор
        /// </summary>
        public  string Id { get; set; }
        /// <summary>
        /// Выпускающая организация
        /// </summary>
        public  string Issuer { get; set; }
        /// <summary>
        /// Начало действия
        /// </summary>
        public  DateTime ValidFrom { get; set; }
        /// <summary>
        /// Конец действия
        /// </summary>
        public  DateTime ValidTo { get; set; }
    }
}
