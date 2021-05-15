using System.Threading.Tasks;
using Models.Security;
using Models.ViewModels;

namespace WebApiHandlers.Interfaces
{
    /// <summary>
    /// Провайдер для работы с пользователями
    /// </summary>
    public interface IUserProvider
    {
        
        /// <summary>
        /// Получение пользователя
        /// </summary>
        /// <returns></returns>
        Task<ApplicationUser> GetApplicationUserAsync(string userName, string password);

        /// <summary>
        /// Регистрация пользователя
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task RegisterUserAsync(RegisterViewModel model);
    }
}
