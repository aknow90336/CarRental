using System.Collections.Generic;
using CarRental.DataAccess.DB.CarDB;

namespace CarRental.DataAccess.Interface
{
    public interface ICarRepository
    {
        List<Car> GetCarList();
    }
}