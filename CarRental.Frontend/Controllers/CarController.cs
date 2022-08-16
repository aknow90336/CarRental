using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CarRental.Frontend.Models;
using CarRental.Service;
using CarRental.Frontend.Models.Car;

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
        public IActionResult Detail(ulong id)
        {
            var result = new CarDetailResponseModel(){
                Car = this._carService.GetCarDetailById(id),
                Mercnaht = this._carService.GetMerechantDetailById(id)
            };
            return View(result);
        }

        // [HttpPost]
        // public IActionResult GetDetail(ulong id)
        // {
        //     var result = new CarDetailResponseModel(){
        //         Car = this._carService.GetCarDetailById(id),
        //         Mercnaht = this._carService.GetMerechantDetailById(id)
        //     return View(result);
        // }        
        
        [HttpGet]
        public IActionResult GetDetail(ulong id)
        {
            throw new System.Exception();
            return this.Content("Success");
        }
    }
}
