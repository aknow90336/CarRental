using System.Collections.Generic;
using CarRental.DataAccess.DB.CarDB;

namespace CarRental.DataAccess.Interface
{
    public interface ICarRepository
    {
        public List<Car> GetCarList();

        public Car GetCarDetailById(ulong id);

        public Merchant GetMerechantDetailById(ulong id);
    }
}