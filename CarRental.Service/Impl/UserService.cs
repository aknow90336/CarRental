using System;
using System.Security.Cryptography;
using System.Text;
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

        public uint AddUser(string name, string phone, string pwd)
        {
            if(string.IsNullOrEmpty(name)||string.IsNullOrEmpty(phone)||string.IsNullOrEmpty(pwd))
            {
                throw new UserException(UserExceptionCode.ParameterError, "invalid loging parameter.");
            }

            return this._userRepository.AddUser(new User()
            {
                Name = name,
                Phone = phone,
                Password = this.Hash(pwd)
            });
        }

        public void Login(string phone, string password)
        {
            //var user = this._userRepository.GetUserByPhone(phone);
        }

        public string Hash(string password)
        {
            using (SHA256CryptoServiceProvider csp = new SHA256CryptoServiceProvider())
            {
                var salt = "salt";
                return BitConverter.ToString(csp.ComputeHash(Encoding.UTF8.GetBytes(salt+password))).Replace("-", string.Empty).ToLower();
            }
        }
    }
}