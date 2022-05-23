using CarRental.DataAccess.DB.CarDB;

namespace CarRental.DataAccess.Interface
{
    public interface IUserRepository
    {
        User GetUser(uint id);

        public User GetUserByPhone(string phone);

        uint AddUser(User user);

        void UpdateUser(User user);
    }
}