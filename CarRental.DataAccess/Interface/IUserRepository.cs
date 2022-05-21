using CarRental.DataAccess.DB.CarDB;

namespace CarRental.DataAccess.Interface
{
    public interface IUserRepository
    {
        public User GetUserByPhone(string phone);

        uint AddUser(User user);
    }
}