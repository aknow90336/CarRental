using System;
using System.Collections.Generic;

#nullable disable

namespace CarRental.DataAccess.DB.CarDB
{
    public partial class Car
    {
        public ulong Id { get; set; }
        public uint MerchantId { get; set; }
        public uint MakeId { get; set; }
        public uint ModelId { get; set; }
        public string Plate { get; set; }
        public sbyte Body { get; set; }
        public sbyte TransmissionType { get; set; }
        public sbyte DoorNum { get; set; }
        public sbyte Seat { get; set; }
        public DateTime? PlateDate { get; set; }
        public sbyte? InsuranceType { get; set; }
        public decimal? NormalPrice { get; set; }
        public decimal? FridayPrice { get; set; }
        public decimal? WeekendsPrice { get; set; }
        public decimal? HolidayPrice { get; set; }
        public decimal? CustomPrice { get; set; }
        public sbyte Status { get; set; }
        public DateTime? CreatedTime { get; set; }
        public string Creator { get; set; }
        public DateTime? UpdatedTime { get; set; }
        public string Updator { get; set; }
        public bool? ValidFlag { get; set; }
    }
}
