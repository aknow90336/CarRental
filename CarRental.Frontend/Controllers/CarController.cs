using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CarRental.Frontend.Models;

namespace CarRental.Frontend.Controllers
{
    public class CarController : Controller
    {
        private readonly ILogger<CarController> _logger;

        public CarController(ILogger<CarController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult List(CarSearchModel model)
        {
            return View(model);
        }

        [HttpGet]
        public IActionResult Detail(string id)
        {
            return View();
        }
    }
}
