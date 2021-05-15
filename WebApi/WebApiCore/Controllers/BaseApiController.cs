using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace WebApiCore.Controllers
{
    /// <summary>
    /// Базовый контроллер
    /// </summary>
    [Authorize]
    public class BaseApiController : ControllerBase
    {
        /// <summary>
        /// Менеджер логирования
        /// </summary>
        protected readonly ILogger<BaseApiController> Logger;

        /// <summary>
        /// Роль пользователя с доступом к внутренним сервисам
        /// </summary>
        protected const string InnerServiceRole = "InnerServices";

        /// <summary>
        /// Роль пользователя с доступом к сервисам feip
        /// </summary>
        protected const string FeipServiceRole = "FeipService";
        
        /// <summary>
        /// Роль пользователя с доступом к сервисам яндекс
        /// </summary>
        protected const string YandexServiceRole = "YandexService";

        /// <summary>
        /// Роль пользователя с доступом к внутренним сервисам
        /// </summary>
        protected const string SiteServiceRole = "SiteServices";

        /// <summary>
        /// Конструктор базового контроллера
        /// </summary>
        /// <param name="appSettings"></param>
        /// <param name="contextAccessor"></param>
        /// <param name="logger"></param>
        public BaseApiController(IHttpContextAccessor contextAccessor,
            ILogger<BaseApiController> logger)
        {
            Logger = logger;
        }

        /// <summary>
        /// Id текущего залогиненного пользователя
        /// </summary>
        private Guid GetUserAdGuid(IHttpContextAccessor contextAccessor)
        {
                try
                {
                    if (User != null)
                    {
                        var value = ((ClaimsIdentity)contextAccessor.HttpContext.User?.Identity)?.Claims
                            .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
                        return value == null ? Guid.Empty : new Guid(value);
                    }
                    return Guid.Empty;
                }
                catch (Exception)
                {
                    return Guid.Empty;
                }
        }
    }
}
