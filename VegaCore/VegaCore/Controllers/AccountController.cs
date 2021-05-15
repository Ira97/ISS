using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Models.Security;
using Vega.Models;
using WebApiHandlers.Interfaces;

namespace Vega.Controllers
{
    /// <summary>
    /// Контроллер для работы с аккаунтами
    /// </summary>
    public class AccountController : Controller
    {
        private readonly IAccessTokenProvider _accessTokenProvider;

        /// <summary>
        /// Инициализирует экземпляр <see cref="AccountController"/>
        /// </summary>
        /// <param name="accessTokenProvider"></param>
        /// <param name="httpClientProvider"></param>
        public AccountController(IAccessTokenProvider accessTokenProvider, IWebHttpClientProvider httpClientProvider)
        {
            _accessTokenProvider = accessTokenProvider;
        }

        /// <summary>
        /// Вход
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            var model = new LoginViewModel();
            return View(model);
        }

        /// <summary>
        /// Вход
        /// </summary>
        /// <param name="model"></param>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var applicationUser = await _accessTokenProvider.GetApplicationUserAsync(model.UserName, model.Password);
            if(applicationUser == null)
            {
                ModelState.AddModelError(string.Empty, "Ошибка при получении данных");
                return View(model);
            }
            if (applicationUser.Id == null)
            {
                ModelState.AddModelError(string.Empty, "Неверное имя пользователя или пароль");
                return View(model);
            }
            await Authenticate(applicationUser);
            if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Выход
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            Response.Cookies.Delete("Token");
            return RedirectToAction("Login", "Account");
        }

        private async Task Authenticate(ApplicationUser applicationUser)
        {
            var claims = new List<Claim> { new Claim(ClaimsIdentity.DefaultNameClaimType, applicationUser.UserName) };
            claims.AddRange(applicationUser.Claims);
            var id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
            Response.Cookies.Append("Token", applicationUser.Token);
        }

    }
}
