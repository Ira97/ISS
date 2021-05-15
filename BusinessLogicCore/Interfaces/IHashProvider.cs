using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicCore.Interfaces
{
    /// <summary>
    /// Провайдер для работы с алгоритмами хеширования
    /// </summary>
    public interface IHashProvider
    {
        /// <summary>
        /// Хеширование с помощью MD5
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        string HashMd5(string input);
        /// <summary>
        /// Хеширование с помощью SHA1
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        string HashSha1(string input);
    }
}
