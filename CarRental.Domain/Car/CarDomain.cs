namespace CarRental.Domain.Car
{
    public class CarDomain
    {
        public bool id;

        public sbyte DoorNum { get; set; }
        
        public sbyte Seat { get; set; }

        public ulong Id { get; set; }

        public decimal? CustomPrice { get; set; }

        public sbyte TransmissionType { get; set; }

        public sbyte? InsuranceType { get; set; }

        public decimal? NormalPrice { get; set; }

        public decimal? FridayPrice { get; set; }

        public decimal? WeekendsPrice { get; set; }

        public decimal? HolidayPrice { get; set; }
    }
}