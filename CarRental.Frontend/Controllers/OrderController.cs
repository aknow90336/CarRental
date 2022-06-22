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
using CarRental.Domain.Neweb;
using CarRental.Service.Lib;
using System.Text;
using System.Security.Cryptography;

namespace CarRental.Frontend.Controllers
{
    public class OrderController : BaseController
    {

        private readonly IUserService _userService;

        private readonly ILogger<OrderController> _logger;

        public OrderController(IUserService userService, ILogger<OrderController> logger)
        {
            this._userService = userService;
            this._logger = logger;
        }

        [HttpGet]
        public IActionResult Detail()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Pay(NewebPayModel model)
        {
            var authContent = new NewebAuthDomain()
            {
                MerchantID = "MS335765599",
                TokenTerm = $"ANJOY_LIFE_{1}"
                //ReturnURL = "http://localhost/api/card/bind_card_callback?user_id={user.Id}",
            };
            var key = "EWxQVz8Tc3PvOBiN3hfm9o54oFNjGFDR";
            var iv = "CnprlTUxijKpRvtP";

            var tradeInfo = new AESEncrypt().EncryptAES256(authContent.PropUrlEncode(), "EWxQVz8Tc3PvOBiN3hfm9o54oFNjGFDR", "CnprlTUxijKpRvtP");  
            var tradeSha = this.getHashSha256($"HashKey={key}&{tradeInfo}&HashIV={iv}").ToUpper();
            var result = new PayModel()
            {
                NewebUrl = "https://ccore.newebpay.com/MPG/mpg_gateway",
                MerchantID = authContent.MerchantID,
                TradeInfo = tradeInfo,
                TradeSha = tradeSha,
            };

            return View(result);
        }

        public string getHashSha256(string text)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(text);
            SHA256Managed hashstring = new SHA256Managed();
            byte[] hash = hashstring.ComputeHash(bytes);
            string hashString = string.Empty;
            foreach (byte x in hash)
            {
            hashString += String.Format("{0:x2}", x);
            }
            return hashString.ToUpper();
        }
        private string SHA256(string text)
        {
            using (SHA256CryptoServiceProvider csp = new SHA256CryptoServiceProvider())
            {
                return BitConverter.ToString(csp.ComputeHash(Encoding.UTF8.GetBytes(text))).Replace("-", string.Empty).ToLower();
            }
        }
    }
}
