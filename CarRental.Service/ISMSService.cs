namespace CarRental.Service
{
    public interface ISMSService
    {
        void SendLongSMS(string act, string dstName, string mobile, string message);

        void SmsCallBack(string msgId, int statusFlag);
    }
}