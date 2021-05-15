using System;
using System.Globalization;

namespace Models.CustomException
{
    public class AppException : Exception
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="AppException"/>
        /// </summary>
        public AppException() : base() { }
        /// <summary>
        /// Инициализирует экземпляр <see cref="AppException"/>
        /// </summary>
        public AppException(string message) : base(message) { }
        /// <summary>
        /// Инициализирует экземпляр <see cref="AppException"/>
        /// </summary>
        public AppException(string message, params object[] args)
            : base(string.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
