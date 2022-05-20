using CarRental.Domain.Car;

namespace CarRental.Frontend.Models.Car
{
    public class CarDetailResponseModel
    {
        public MerchantDomain Mercnaht { get; set; }
        public CarDomain Car { get; set; }
    }
}