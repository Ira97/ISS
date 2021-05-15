using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using BusinessLogicCore.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace BusinessLogicCore.Controllers
{
    /// <inheritdoc cref="IHashProvider"/>
    public class HashProvider : IHashProvider
    {
        /// <summary>
        /// Инициализирует экземпляр <see cref="HashProvider"/>
        /// </summary>
        /// <param name="appSettings"></param>
        /// <param name="logger"></param>
        public HashProvider() : base()
        {
        }

        /// <inheritdoc />
        public string HashMd5(string input)
        {
            using var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
            return Convert.ToBase64String(hash);
        }

        /// <inheritdoc />
        public string HashSha1(string input)
        {
            using var sha1 = new SHA1Managed();
            var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(input));
            var sb = new StringBuilder(hash.Length * 2);
            foreach (var b in hash)
            {
                sb.Append(b.ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
