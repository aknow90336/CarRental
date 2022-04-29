using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CarRental.Frontend.Models;
using CarRental.Service;
using CarRental.Frontend.Models.Car;
using System;
using System.Linq;

namespace CarRental.Frontend.Controllers
{
    public class CarController : Controller
    {
        private readonly ILogger<CarController> _logger;

        private readonly ICarService _carService;

        public CarController(ILogger<CarController> logger, ICarService carService)
        {
            this._logger = logger;
            this._carService = carService;
        }

        [HttpGet]
        public IActionResult List(CarSearchModel model)
        {
            return View(new CarListResponseModel(){
                CarList = this._carService.GetCarList()
            });
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            var item = this._carService.GetDetailResponseModel();
            var getResultById = item.FirstOrDefault(i => i.id);
            return View(getResultById);
        }
    }
}
