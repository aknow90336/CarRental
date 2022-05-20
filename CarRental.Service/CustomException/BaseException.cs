using System;

namespace CarRental.Service.CustomException
{
    public class BaseException : Exception
    {
        public string message;

        public string code;

        public BaseException(string msg, string code) : base(msg)
        {
            this.message = msg;
            this.code = code;
        }
    }
}