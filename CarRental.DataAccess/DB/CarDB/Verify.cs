using System;
using System.Collections.Generic;

#nullable disable

namespace CarRental.DataAccess.DB.CarDB
{
    public partial class Verify
    {
        public uint Id { get; set; }
        public string Phone { get; set; }
        public string Code { get; set; }
        public string MerchantId { get; set; }
        public int Status { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
