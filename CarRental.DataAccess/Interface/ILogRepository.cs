using CarRental.DataAccess.DB.CarDB;

namespace CarRental.DataAccess.Interface
{
    public interface ILogRepository
    {
        SmsLog GetSmsLog(string msgId);
        
        SmsLog AddSmsLog(SmsLog smsLog);

        void UpdateSmsLog(SmsLog smsLog);
    }
}