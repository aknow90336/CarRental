using CarRental.DataAccess.Interface;
using CarRental.DataAccess.DB.CarDB;
using CarRental.Service.CustomException;

namespace CarRental.Service.Impl
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(ICarRepository carRepository, IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public bool IsUser(string phone)
        {
            var user = this._userRepository.GetUserByPhone(phone);

            return user != null;
        }

        public void AddUser(string name, string phone, string pwd)
        {
            if(string.IsNullOrEmpty(name)||string.IsNullOrEmpty(phone)||string.IsNullOrEmpty(pwd))
            {
                throw new UserException(UserExceptionCode.Test, "invalid invitation.");
            }

            this._userRepository.AddUser(new User()
            {
                
            });
        }

        public void Login(string phone, string password)
        {
            //var user = this._userRepository.GetUserByPhone(phone);
        }
    }
}