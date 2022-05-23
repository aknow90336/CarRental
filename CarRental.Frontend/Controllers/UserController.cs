using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using System.Security.Claims;
using CarRental.Frontend.Models;
using CarRental.Service;
using CarRental.Service.CustomException;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace CarRental.Frontend.Controllers
{
    [Authorize]
    public class UserController : BaseController
    {
        private readonly ICompositeViewEngine _compositeViewEngine;

        private readonly IUserService _userService;

        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, ILogger<UserController> logger, ICompositeViewEngine compositeViewEngine)
        {
            this._userService = userService;
            this._logger = logger;
            this._compositeViewEngine = compositeViewEngine;
        }

        [HttpGet]
        public IActionResult Detail()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Login(UserLoginModel model)
        {
            Dictionary<ReturnKey, object> result = new Dictionary<ReturnKey, object>();

            var user = this._userService.GetUser(model.Phone);

            if(user == null)
            {
                throw new UserException(UserExceptionCode.UserNotFound, "使用者不存在.");
            }

            if(user.Password !=  this._userService.Hash(model.Pwd))
            {
                throw new UserException(UserExceptionCode.PwdError, "密碼錯誤.");
            }
            this.SetToken(user.Id.ToString(),  user.Phone, user.Name);
            return this.Content(JsonSerializer.Serialize(result));
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Register(RegisterModel model)
        {   
            Dictionary<ReturnKey, object> result = new Dictionary<ReturnKey, object>();
            var userId = this._userService.AddUser(model.Name, model.Phone, model.Pwd).ToString();
            this.SetToken(userId.ToString(), model.Phone, model.Name);
            return this.Content(JsonSerializer.Serialize(result));
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult IsUser(UserCheckModel model)
        {
            Dictionary<ReturnKey, object> result = new Dictionary<ReturnKey, object>();
            model.IsUser = this._userService.IsUser(model.Phone);
            result.Add(ReturnKey.Result, base.RenderPartialViewToString(this._compositeViewEngine,"LoginPartial", model));
            return this.Content(JsonSerializer.Serialize(result));
        }

        private async void SetToken(string userId, string phone, string name)
        {
            var claim = new [] {
                new Claim("UserId", userId),
                new Claim("Phone", phone),
                new Claim("Name", name),
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claim, CookieAuthenticationDefaults.AuthenticationScheme);
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            await HttpContext.SignInAsync(claimsPrincipal, new AuthenticationProperties()
            {
                AllowRefresh = false,
                IsPersistent = true,
                ExpiresUtc = DateTimeOffset.UtcNow.AddDays(1)
            });
        }
    }
}
