using System.Linq;
using CarRental.DataAccess.Interface;
using CarRental.DataAccess.DB.CarDB;

namespace CarRental.DataAccess.Repository
{
    public class MerchantRepository : IMerchantRepository
    {
        private readonly CarDBContext _dbContext;

        public MerchantRepository(CarDBContext carDBContext)
        {
            this._dbContext = carDBContext;
        }
    }
}