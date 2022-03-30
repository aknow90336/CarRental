using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CarRental.Frontend.Models;
using CarRental.Service;
using CarRental.Frontend.Models.Car;

namespace CarRental.Frontend.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;


        public UserController(ILogger<UserController> logger, ICarService carService)
        {
            this._logger = logger;
        }

        [HttpGet]
        public IActionResult Login(CarSearchModel model)
        {
            return View();
        }
    }
}
