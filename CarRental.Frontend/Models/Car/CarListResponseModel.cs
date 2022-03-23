using System.Collections.Generic;
using CarRental.Domain.Car;

namespace CarRental.Frontend.Models.Car
{
    public class CarListResponseModel
    {
        public List<CarDomain> CarList { get; set; }
    }
}