using System;
using System.Collections.Generic;
using CarRental.Domain.Car;

namespace CarRental.Service
{
    public interface ICarService
    {
        List<CarDomain> GetCarList();

        List<CarDomain> GetDetailResponseModel();
    }
}