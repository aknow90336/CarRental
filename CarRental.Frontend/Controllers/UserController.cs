using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CarRental.Frontend.Models;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using CarRental.Service;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

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
        [AllowAnonymous]
        public IActionResult Login(CarSearchModel model)
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Register(RegisterModel model)
        {   
            Dictionary<ReturnKey, object> result = new Dictionary<ReturnKey, object>();
            var claim = new [] {
                new Claim("UserId", this._userService.AddUser(model.Name, model.Phone, model.Pwd).ToString()),
                new Claim("Phone", model.Phone),
                new Claim("Name", model.Name),
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claim, CookieAuthenticationDefaults.AuthenticationScheme);
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            await HttpContext.SignInAsync(claimsPrincipal, new AuthenticationProperties()
            {
                AllowRefresh = false,
                IsPersistent = true,
                ExpiresUtc = DateTimeOffset.UtcNow.AddDays(1)
            });

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
    }
}
