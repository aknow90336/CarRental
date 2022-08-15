using System;

namespace CarRental.Domain.Car
{
    public class MerchantDomain
    {
        public ulong Id { get; set; }

        public string Name { get; set; }

        public string TaxId { get; set; }
        
        public string ManagerName { get; set; }
        public int? ManagerPhone { get; set; }
        public string Tel { get; set; }
        public string Mail { get; set; }
        public string LocationCity { get; set; }
        public string LocationArea { get; set; }
        public string LocationCode { get; set; }
        public string LocationAddr { get; set; }
        public decimal? LocationLon { get; set; }
        public decimal? LocationLat { get; set; }
        public TimeSpan? NormalStart { get; set; }
        public TimeSpan? NormalEnd { get; set; }
        public TimeSpan? WeekendsStart { get; set; }
        public TimeSpan? WeekendsEnd { get; set; }
        public string Desc { get; set; }
        public sbyte Status { get; set; }
        public DateTime? CreatedTime { get; set; }
    }
}