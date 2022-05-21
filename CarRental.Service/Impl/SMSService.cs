using System;
using System.IO;
using System.Web;
using System.Text;
using Microsoft.Extensions.Configuration;
using CarRental.DataAccess.Interface;
using CarRental.DataAccess.DB.CarDB;
using System.Net;

namespace CarRental.Service.Impl
{
    public class SMSService : ISMSService
    {
        private readonly ILogRepository _logRepository;

        private readonly IConfiguration _configuration;

        private readonly string _smsAct;

        private readonly string _smsPwd;

        private readonly string _storeUrl;

        public SMSService(ILogRepository logRepository, IConfiguration configuration)
        {
            this._logRepository = logRepository;
            this._configuration = configuration;
        }

        public void SendLongSMS(string act, string dstName, string mobile, string message)
        {
            string msg = HttpUtility.UrlEncode(message).Replace("+", "%20");
            DateTime sendTime = DateTime.Now;
            DateTime expiredTime = DateTime.Now.AddDays(1);

            var log = new SmsLog(){
                Act = act,
                MsgId = "",
                Message = message.ToString(),
                DstAddr = mobile.Trim(),
                DestName = dstName.Trim(),
                SendTime = sendTime,
                DlvTime = DateTime.Parse("1911/1/1"),
                DoneTime = DateTime.Parse("1911/1/1"),
                Note = "",
                IsSend = 0,
                IsDlv = 0,
                CreateTime = DateTime.Now,
            };

            log = this._logRepository.AddSmsLog(log);

            string uri = string.Format($"{this._configuration["SMS:Mitake:URL"]}/api/mtk/SmSend?username={this._configuration["SMS:Mitake:Act"]}&password={this._configuration["SMS:Mitake:Pwd"]}&dstaddr={mobile}&DestName={dstName}&dlvtime={sendTime.ToString("yyyyMMddHHmmss")}&vldtime={expiredTime.ToString("yyyyMMddHHmmss")}&smbody={msg}&Clientid={Guid.NewGuid()}&CharsetURL=utf-8&response={$"{this._configuration["CarURL"]}/callback/smscallback"}");

            HttpWebRequest request = WebRequest.Create(uri) as HttpWebRequest;
            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream, Encoding.UTF8);
            string note = reader.ReadToEnd();

            //取得MsgID
            string[] result = note.Split(new char[] { '\n' });
            if (result.Length > 1)
            {
                if (result[1].IndexOf("msgid") >= 0)
                {
                    string msgid = result[1].Trim().Replace("msgid=", "");
                    log.MsgId = msgid;
                    log.IsSend = 1;
                }
            }

            log.DoneTime = DateTime.Now;
            log.Note = note;

            this._logRepository.UpdateSmsLog(log);
        }

        public void SmsCallBack(string msgId, int statusFlag)
        {
            var log = this._logRepository.GetSmsLog(msgId);
            log.StatusFlag = statusFlag;
            log.UpdatedTime = DateTime.Now;
            this._logRepository.UpdateSmsLog(log);
        }
    }
}