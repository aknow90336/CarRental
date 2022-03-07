using System;
namespace CarRental.Frontend.Models
{
    public class CarSearchModel
    {
        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        public int Seat { get; set; }

        public decimal Lat { get; set; }

        public decimal Lng { get; set; }
     }
}