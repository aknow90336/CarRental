using CarRental.Domain.User;

namespace CarRental.Service
{
    public interface IUserService
    {
        UserDomain GetUser(string phone);

        bool IsUser(string phone);

        uint AddUser(string name, string phone, string pwd);

        string Hash(string password);
    }
}