using CarRental.DataAccess.Interface;

namespace CarRental.Service.Impl
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(ICarRepository carRepository, IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public void Login(string phone, string password)
        {
            var user = this._userRepository.GetUserByPhone(phone);
        }
    }
}