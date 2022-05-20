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

        public Car GetCarDetailById(ulong id)
        {
            return this._dbContext.Cars.Where(i => i.Id == id).FirstOrDefault();
        }

        public Merchant GetMerechantDetailById(ulong id)
        {
            return this._dbContext.Merchants.Where(i => i.Id == id).FirstOrDefault();
        }
    }
}