using System.Threading.Tasks;

namespace WebApiHandlers.Interfaces
{
    /// <summary>
    /// Обращение к WebApi по HttpClient
    /// </summary>
    public interface IWebHttpClientProvider
    {
        /// <summary>
        /// Отправка http get запроса
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        Task<T> SendHttpGetRequest<T>(string url) where T : class;
        /// <summary>
        /// Отправка http post запроса
        /// </summary>
        /// <param name="data"></param>
        /// <param name="url"></param>
        Task<bool> SendHttpPostRequest(object data, string url);
        /// <summary>
        /// Отправка http post запроса
        /// </summary>
        /// <param name="data"></param>
        /// <param name="url"></param>
        Task<T> SendHttpPostWithResponse<T>(object data, string url) where T : new();
        /// <summary>
        /// Отправка http delete запроса
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        Task<T> SendHttpDeleteRequest<T>(string url) where T : new();

        /// <summary>
        /// Отправка http update запроса
        /// </summary>
        /// <param name="data"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        Task<long> SendHttpPutRequest(object data, string url);
    }
}
