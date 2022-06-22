using System;

namespace CarRental.Domain.Neweb
{
    public class NewebAuthDomain
    {
        public NewebAuthDomain()
        {
            var timeStamp = (int)DateTime.Now.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
            this.RespondType = "JSON";
            this.TimeStamp = timeStamp.ToString();
            this.Version = "2.0";
            this.ItemDesc = "品項名稱";
            this.LoginType = 0;
            this.MerchantOrderNo = $"{new Random().Next(0, 10000000).ToString("D7")}{timeStamp}";
            this.Amt = 1;
            this.CREDIT = 1 ;
        }

        public string MerchantID { get; set; }

        public string RespondType { get; set; }

        public string TimeStamp { get; set; }

        public string Version { get; set; }

        public string MerchantOrderNo { get; set; }

        public int Amt { get; set; }

        public string ItemDesc { get; set; }

        public int LoginType { get; set; }

        public string TokenTerm { get; set; }

        public string ReturnURL { get; set; }

        public int? CREDIT { get; set; }
    }
}