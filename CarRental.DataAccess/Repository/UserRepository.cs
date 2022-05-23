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

        public User GetUser(uint id)
        {
            return this._dbContext.Users.Where(t=>t.Id == id).FirstOrDefault();
        }

        public User GetUserByPhone(string phone)
        {
            return this._dbContext.Users.Where(t=>t.Phone == phone).FirstOrDefault();
        }

        public uint AddUser(User user)
        {
            this._dbContext.Users.Add(user);
            this._dbContext.SaveChanges();
            return user.Id;
        }

        public void UpdateUser(User user)
        {
            this._dbContext.Users.Update(user);
            this._dbContext.SaveChanges();
        }
    }
}