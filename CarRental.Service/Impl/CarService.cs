using CarRental.DataAccess.Interface;
using System.Collections.Generic;
using CarRental.Domain.Car;

namespace CarRental.Service.Impl
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;

        public CarService(ICarRepository carRepository)
        {
            this._carRepository = carRepository;
        }

        public List<CarDomain> GetCarList()
        {   
            List<CarDomain> result = new List<CarDomain>();

            // N Mapping
            foreach(var item in this._carRepository.GetCarList())
            {
                result.Add(new CarDomain(){
                    DoorNum = item.DoorNum,
                    Seat = item.Seat,
                    Id = item.Id
                });
            }
            
            return result;
        }

        public List<CarDomain> GetDetailResponseModel()
        {
            List<CarDomain> result = new List<CarDomain>();
            foreach(var item in this._carRepository.GetDetailResponseModel())
            {
                result.Add(new CarDomain(){
                    Seat = item.Seat,
                    DoorNum = item.DoorNum,
                    CustomPrice = item.CustomPrice,
                    NormalPrice = item.NormalPrice,
                    HolidayPrice = item.HolidayPrice
                });
            }
            return result;
        }

    }
}