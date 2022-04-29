namespace CarRental.Frontend.Models.Car
{
    public class CarDetailResponseModel
    {
        public int Seat { get; set; }

        public int DoorNum { get; set; }

        public string Name { get; set; }

        public int CarBrandId { get; set; }

        public int  ModelId { get; set; } 

        public int TransmissionType { get; set; }

        public int? InsuranceType { get; set; }

        public decimal? NormalPrice { get; set; }

        public decimal? FridayPrice { get; set; }

        public decimal? WeekendsPrice { get; set; }

        public decimal? HolidayPrice { get; set; }

        public decimal? CustomPrice { get; set; }

        public int Status { get; set; }
    }
}