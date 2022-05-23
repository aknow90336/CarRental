using System;
using System.Linq;
using CarRental.DataAccess.Interface;
using CarRental.DataAccess.DB.CarDB;
using CarRental.Service.CustomException;

namespace CarRental.Service.Impl
{
    public class VerifyService: IVerifyService
    {
        private readonly IVerifyRepository _verifyRepository;

        private readonly IUserRepository _userRepository;

        private readonly ISMSService _smsService;

        public VerifyService(IVerifyRepository verifyRepository,
                             IUserRepository userRepository,
                             ISMSService smsService)
        {
            this._smsService = smsService;
            this._userRepository = userRepository;
            this._verifyRepository = verifyRepository;
        }

        public void VerifySend(string phone)
        {
            var lastVerify = this._verifyRepository.GetVerifyByPhone(phone).Where(t=>t.Status.Equals(0) && t.CreatedTime.AddMinutes(1)>DateTime.Now);

            if(lastVerify.Any())
            {
                throw new VerifyException(VerifyExceptionCode.DuplicateError, "發送過於頻繁，請稍後再試一次");
            }

            var smsCode = new Random().Next(000001, 999999).ToString("000000");

            var message = $"【UB24Car】驗證碼：{smsCode}，有效時間為30分鐘。";

            var domain = new Verify()
            {
                Phone = phone,
                Code = smsCode,
                Status = 0,
                CreatedTime = DateTime.Now
            };

            this._verifyRepository.AddVerify(domain);
            this._smsService.SendLongSMS("帳號註冊", "SYSTEM", phone, message);
        }

        public string VerifyPhone(uint id, string code)
        {
            var user = this._userRepository.GetUser(id);
            var verify = this._verifyRepository.GetVerifyByPhone(user.Phone).Where(t=>t.Status.Equals(0)).OrderByDescending(x => x.CreatedTime).FirstOrDefault();

            if (verify == null)
                throw new VerifyException(VerifyExceptionCode.NoVerifyToken, "無驗證資訊");

            if (verify.CreatedTime.AddMinutes(30) < DateTime.Now)
                throw new VerifyException(VerifyExceptionCode.TokenExpired, "驗證資訊已過期");

            if (verify.Code != code)
                throw new VerifyException(VerifyExceptionCode.VerifyCodeError, "驗證碼錯誤");

            var token = this.GetRandomString(16);

            verify.Status = 1;

            this._verifyRepository.UpdateVerify(verify);
            user.IsPhoneVerify = true;
            this._userRepository.UpdateUser(user);

            return token;
        }

        private string GetRandomString(int length)
		{
			const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
			return new string(Enumerable.Repeat(chars, length)
			  .Select(s => s[new Random().Next(s.Length)]).ToArray());
		}
    }
}