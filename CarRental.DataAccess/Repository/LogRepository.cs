using System.Linq;
using CarRental.DataAccess.DB.CarDB;
using CarRental.DataAccess.Interface;

namespace CarRental.DataAccess.Repository
{
    public class LogRepository : ILogRepository
    {
        private readonly CarDBContext _dbContext;

        public LogRepository(CarDBContext carDBContext)
        {
            this._dbContext = carDBContext;
        }
        
        public SmsLog GetSmsLog(string msgId)
        {
            return this._dbContext.SmsLogs.Where(t=>t.MsgId.Equals(msgId)).OrderByDescending(x => x.CreateTime).FirstOrDefault();
        }

        public SmsLog AddSmsLog(SmsLog smsLog)
        {
            this._dbContext.SmsLogs.Add(smsLog);
            this._dbContext.SaveChanges();
            return smsLog;
        }

        public void UpdateSmsLog(SmsLog smsLog)
        {
            this._dbContext.SmsLogs.Update(smsLog);
            this._dbContext.SaveChanges();
        }
    }
}