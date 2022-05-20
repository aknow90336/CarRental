using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CarRental.Frontend.Models;
using CarRental.Service.Lib;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using System.Collections.Generic;
using System.Text.Json;
using CarRental.Service;

namespace CarRental.Frontend.Controllers
{
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
        public IActionResult Login(CarSearchModel model)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterModel model)
        {
            
            return Ok();
        }


        [HttpPost]
        public IActionResult IsUser(UserCheckModel model)
        {
            Dictionary<ReturnKey, object> result = new Dictionary<ReturnKey, object>();
            model.IsUser = this._userService.IsUser(model.Phone);
            result.Add(ReturnKey.Result, base.RenderPartialViewToString(this._compositeViewEngine,"LoginPartial", model));
            //throw new UserException(UserExceptionCode.Test, "invalid invitation.");
            return this.Content(JsonSerializer.Serialize(result));
        }

        // [HttpPost]
        // public IActionResult GetLoginPartialView(UserCheckModel model)
        // {
        //     return Ok(Result.GetResult(base.RenderPartialViewToString(this._compositeViewEngine,"LoginPartial", null)));
        // }

        
        [HttpPost]
        public IActionResult GetRegisterPartialView(UserCheckModel model)
        {
            return Ok(Result.GetResult(true));
        }
    }
}
