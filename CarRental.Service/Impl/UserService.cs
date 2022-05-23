using System;
using System.Security.Cryptography;
using System.Text;
using CarRental.DataAccess.Interface;
using CarRental.DataAccess.DB.CarDB;
using CarRental.Service.CustomException;
using CarRental.Domain.User;
using AutoMapper;
namespace CarRental.Service.Impl
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        private IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            this._mapper = mapper;
            this._userRepository = userRepository;
        }

        public UserDomain GetUser(string phone)
        {
            return this._mapper.Map<UserDomain>(this._userRepository.GetUserByPhone(phone));
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