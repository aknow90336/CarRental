
namespace CarRental.Service.CustomException
{
  public class VerifyException : BaseException
    {
        public static string errorPrefix = "VE";

        public VerifyExceptionCode _code;

        public VerifyException(VerifyExceptionCode code, string msg) : base(msg, $"{errorPrefix}-{((int)code).ToString("d4")}")
        {
            this._code = code;
        }
    }

    public enum VerifyExceptionCode
    {
        DuplicateError = 1,

        NoVerifyToken = 2,

        TokenExpired = 3,

        VerifyCodeError = 4,
    }
}