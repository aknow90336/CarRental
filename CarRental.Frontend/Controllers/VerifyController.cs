using System.Collections.Generic;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using CarRental.Frontend.Models;
using CarRental.Service;

namespace CarRental.Frontend.Controllers
{
    [Authorize]
    public class VerifyController : Controller
    {
        private readonly ILogger<VerifyController> _logger;

        private readonly ISMSService _smsService;

        public VerifyController(ILogger<VerifyController> logger)
        {
            //this._smsService = smsService;
            this._logger = logger;
        }
        
        [HttpGet]
        public IActionResult Phone()
        {
            //this._smsService.SendLongSMS("活動邀請", "SYSTEM", "0986810117", $"您好這是測試");
            return View(new VerifyPhoneModel(){
                Phone = User.FindFirst("Phone").Value
            });
        }

        [HttpPost]
        public IActionResult Resend(VerifyPhoneModel model)
        {
            Dictionary<ReturnKey, object> result = new Dictionary<ReturnKey, object>();
            
            return this.Content(JsonSerializer.Serialize(result));
        }

        [HttpPost]
        public IActionResult Phone(UserCheckModel model)
        {
            Dictionary<ReturnKey, object> result = new Dictionary<ReturnKey, object>();

            return this.Content(JsonSerializer.Serialize(result));
        }
    }
}
