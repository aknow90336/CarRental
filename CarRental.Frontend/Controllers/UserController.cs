using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CarRental.Frontend.Models;
using CarRental.Service;
using CarRental.Service.Lib;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace CarRental.Frontend.Controllers
{
    public class UserController : BaseController
    {
        private readonly ICompositeViewEngine _compositeViewEngine;

        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger, ICompositeViewEngine compositeViewEngine)
        {
            this._logger = logger;
            this._compositeViewEngine = compositeViewEngine;
        }

        [HttpGet]
        public IActionResult Login(CarSearchModel model)
        {
            return View();
        }

        [HttpPost]
        public IActionResult IsUser(UserCheckModel model)
        {
            return Ok(Result.GetResult(base.RenderPartialViewToString(this._compositeViewEngine,"LoginPartial", null)));
            // return Ok(Result.GetResult(true));
        }

        [HttpPost]
        public IActionResult GetLoginPartialView(UserCheckModel model)
        {
            return Ok(Result.GetResult(base.RenderPartialViewToString(this._compositeViewEngine,"LoginPartial", null)));
        }

        
        [HttpPost]
        public IActionResult GetRegisterPartialView(UserCheckModel model)
        {
            return Ok(Result.GetResult(true));
        }
    }
}
