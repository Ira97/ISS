using System;
using System.Runtime.Serialization;

namespace Models.CustomException
{
    [Serializable]
    public class CrmException : Exception
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="CrmException"/>
        /// </summary>
        public CrmException()
        {
        }
        /// <summary>
        /// Инициализирует экземпляр <see cref="CrmException"/>
        /// </summary>
        public CrmException(string message, string code) : base(message)
        {
            Code = code;
        }
        /// <summary>
        /// Инициализирует экземпляр <see cref="CrmException"/>
        /// </summary>
        public CrmException(string message, Exception innerException) : base(message, innerException)
        {
        }
        /// <summary>
        /// Инициализирует экземпляр <see cref="CrmException"/>
        /// </summary>
        protected CrmException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
        /// <summary>
        /// Код ошибки Crm
        /// </summary>
        public string Code { get; set; }
    }
}