namespace CarRental.Service.CustomException
{
    public class UserException : BaseException
    {
        public static string errorPrefix = "US";

        public UserExceptionCode _code;

        public UserException(UserExceptionCode code, string msg) : base(msg, $"{errorPrefix}-{((int)code).ToString("d4")}")
        {
            this._code =  code;
        }
    }
    public enum UserExceptionCode
    {
        ParameterError = 1,
    }
}