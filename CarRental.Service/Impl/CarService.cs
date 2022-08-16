using CarRental.DataAccess.Interface;
using System.Collections.Generic;
using CarRental.Domain.Car;
using AutoMapper;

namespace CarRental.Service.Impl
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;

        public CarService(ICarRepository carRepository, IMapper mapper)

        {
            this._mapper = mapper;
            this._carRepository = carRepository;
            this._mapper = mapper;
        }

        public List<CarDomain> GetCarList()
        {   
            var result = this._mapper.Map<List<CarDomain>>(this._carRepository.GetCarList());
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
           var result = this._mapper.Map<CarDomain>(car);
           return result;
        }
    }
}