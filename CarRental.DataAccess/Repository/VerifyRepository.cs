using System.Linq;
using System.Collections.Generic;
using CarRental.DataAccess.Interface;
using CarRental.DataAccess.DB.CarDB;

namespace CarRental.DataAccess.Repository
{
    public class VerifyRepository : IVerifyRepository
    {
        private readonly CarDBContext _dbContext;

        public VerifyRepository(CarDBContext carDBContext)
        {
            this._dbContext = carDBContext;
        }

        public List<Verify> GetVerifyByPhone(string phone)
        {
            return this._dbContext.Verifies.Where(t => t.Phone == phone).ToList();
        }

        public void AddVerify(Verify verify)
        {
            this._dbContext.Verifies.Add(verify);
            this._dbContext.SaveChanges();
        }

        public void UpdateVerify(Verify verify)
        {
            this._dbContext.Verifies.Update(verify);
            this._dbContext.SaveChanges();
        }
    }
}