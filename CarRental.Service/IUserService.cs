namespace CarRental.Service
{
    public interface IUserService
    {
        bool IsUser(string phone);

        uint AddUser(string name, string phone, string pwd);
    }
}