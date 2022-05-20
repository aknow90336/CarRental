using System.Collections.Generic;
using CarRental.Domain.Car;

namespace CarRental.Service
{
    public interface ICarService
    {
        public List<CarDomain> GetCarList();

        public CarDomain GetCarDetailById(ulong id);

        public MerchantDomain GetMerechantDetailById(ulong id);
    }
}