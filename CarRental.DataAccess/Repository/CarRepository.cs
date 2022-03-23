using System.Linq;
using System.Collections.Generic;
using CarRental.DataAccess.Interface;
using CarRental.DataAccess.DB.CarDB;

namespace CarRental.DataAccess.Repository
{
    public class CarRepository : ICarRepository
    {
        private readonly CarDBContext _dbContext;

        public CarRepository(CarDBContext carDBContext)
        {
            this._dbContext = carDBContext;
        }

        public List<Car> GetCarList()
        {
            return this._dbContext.Cars.ToList();
        }
    }
}