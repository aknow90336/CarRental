using System;
using System.Collections.Generic;

#nullable disable

namespace CarRental.DataAccess.DB.CarDB
{
    public partial class SmsLog
    {
        public uint Id { get; set; }
        public string Act { get; set; }
        public string MsgId { get; set; }
        public string Message { get; set; }
        public string DstAddr { get; set; }
        public string DestName { get; set; }
        public DateTime? SendTime { get; set; }
        public DateTime? DlvTime { get; set; }
        public DateTime? DoneTime { get; set; }
        public sbyte? IsSend { get; set; }
        public sbyte? IsDlv { get; set; }
        public string Note { get; set; }
        public int? StatusFlag { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdatedTime { get; set; }
    }
}
