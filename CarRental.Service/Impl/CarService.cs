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

        public MerchantDomain GetMerechantDetailById(ulong id)
        {
            var merchant = this._carRepository.GetMerechantDetailById(id);
            var result = new MerchantDomain(){
            Id = merchant.Id,
            Name = merchant.Name,
            TaxId = merchant.TaxId,
            ManagerName = merchant.ManagerName,
            ManagerPhone = merchant.ManagerPhone,
            Tel = merchant.Tel,
            Mail = merchant.Mail,
            LocationCity = merchant.LocationCity,
            LocationArea = merchant.LocationArea,
            LocationAddr = merchant.LocationAddr,
            LocationLat = merchant.LocationLat,
            LocationLon = merchant.LocationLon,
            NormalStart = merchant.NormalStart,
            NormalEnd = merchant.NormalEnd,
            WeekendsStart = merchant.WeekendsStart,
            WeekendsEnd = merchant.WeekendsEnd
            };

            return result;
        }
            
        public CarDomain GetCarDetailById(ulong id)
        {
           var car = this._carRepository.GetCarDetailById(id);
           CarDomain result = new CarDomain(){
           Seat = car.Seat,
           DoorNum = car.DoorNum,
           CustomPrice = car.CustomPrice,
           NormalPrice = car.NormalPrice,
           HolidayPrice = car.HolidayPrice,
           FridayPrice  = car.FridayPrice,
           WeekendsPrice = car.WeekendsPrice,
           TransmissionType = car.TransmissionType,
           InsuranceType = car.InsuranceType
           };  
           return result;
        }
    }
}