using System.Collections.Generic;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using CarRental.Frontend.Models;
using CarRental.Service;
using System.Text;
using System.Security.Cryptography;
using System;

namespace CarRental.Frontend.Controllers
{
    [Authorize]
    public class VerifyController : Controller
    {
        private readonly ILogger<VerifyController> _logger;

        private readonly IVerifyService _verifyService;

        public VerifyController(ILogger<VerifyController> logger,
                                IVerifyService verifyService)
        {
            this._verifyService = verifyService;
            this._logger = logger;
        }
        
        [HttpGet]
        public IActionResult Phone()
        {
            // todo 檢查使用者是否驗證成功
            return View(new VerifyPhoneModel(){
                Phone = User.FindFirst("Phone").Value
            });
        }

        [HttpPost]
        public IActionResult Resend(VerifyPhoneModel model)
        {
            Dictionary<ReturnKey, object> result = new Dictionary<ReturnKey, object>();
            // todo 檢查使用者是否驗證成功
            this._verifyService.VerifySend(User.FindFirst("Phone").Value);
            return this.Content(JsonSerializer.Serialize(result));
        }

        [HttpPost]
        public IActionResult VerifyPhone(UserCheckModel model)
        {
            Dictionary<ReturnKey, object> result = new Dictionary<ReturnKey, object>();
            this._verifyService.VerifyPhone(Convert.ToUInt16(User.FindFirst("UserId").Value), model.Code);
            return this.Content(JsonSerializer.Serialize(result));
        }
    }
}
