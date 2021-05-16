using System.Collections.Generic;
using System.Security.Claims;

namespace Models.Security
{
    /// <summary>
    /// Пользователь авторизованный
    /// </summary>
    public class ApplicationUser
    {        
        /// <summary>
        /// Сообщение об ошибки
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Логин пользователя
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Номер телефона
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Email адрес
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        public string Patronymic { get; set; }
        /// <summary>
        /// Токен
        /// </summary>
        public string Token { get; set; }
        /// <summary>
        /// Токен
        /// </summary>
        public Token SecurityToken { get; set; }
        /// <summary>
        /// Список claims
        /// </summary>
        public List<Claim> Claims { get; set; }
    }
}
