using System.Threading.Tasks;
using Models.Security;

namespace WebApiHandlers.Interfaces
{
    /// <summary>
    /// Провайдер для получения токена
    /// </summary>
    public interface IAccessTokenProvider
    {
        
        /// <summary>
        /// Получение Токена
        /// </summary>
        /// <returns></returns>
        Task<ApplicationUser> GetApplicationUserAsync(string userName, string password);

    }
}
