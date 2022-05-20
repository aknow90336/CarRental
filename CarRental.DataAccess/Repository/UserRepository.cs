using System.Linq;
using CarRental.DataAccess.Interface;
using CarRental.DataAccess.DB.CarDB;

namespace CarRental.DataAccess.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly CarDBContext _dbContext;

        public UserRepository(CarDBContext carDBContext)
        {
            this._dbContext = carDBContext;
        }

        public User GetUserByPhone(string phone)
        {
            return this._dbContext.Users.Where(t=>t.Phone == phone).FirstOrDefault();
        }

        public void AddUser(User user)
        {
            this._dbContext.Users.Add(user);
            this._dbContext.SaveChanges();
        }
    }
}