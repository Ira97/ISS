using BusinessLogicCore.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Models.User;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace WebApiCore.Controllers
{
    /// <summary>
    /// Контроллер работы с пользователями
    /// </summary>
    [Route("api/user")]
    [AllowAnonymous]
    [SwaggerTag("Контроллер работы с пользователями")]
    public class UserController : BaseApiController
    {
        private readonly IUserService _userService;

        /// <summary>
        /// Инициализирует экземпляр <see cref="UserController"/>
        /// </summary>
        /// <param name="appSettings"></param>
        /// <param name="contextAccessor"></param>
        /// <param name="logger"></param>
        /// <param name="userService"></param>
        public UserController( IHttpContextAccessor contextAccessor,
             ILogger<UserController> logger, IUserService userService)
            : base( contextAccessor, logger)
        {
            _userService = userService;
        }

        /// <summary>
        /// Получение пользователя
        /// </summary>
        /// <returns></returns>
        [HttpPost("register")]
        public async Task RegisterUserAsync([FromBody] RegisterUserDto registerUser)
        {
            await _userService.RegisterUserAsync(registerUser);
        }


        /// <summary>
        /// Получение пользователя
        /// </summary>
        /// <returns></returns>
        [HttpPost("validate")]
        public async Task<User> ValidateUserAsync([FromBody] ValidateUserDto validateUser)
        {
              return await _userService.ValidateUserAsync(validateUser);
        }
    }
}
