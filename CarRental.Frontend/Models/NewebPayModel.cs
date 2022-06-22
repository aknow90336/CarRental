namespace CarRental.Frontend.Models
{
    public class NewebPayModel
    {
        public uint CardId { get; set; }

        public string CarId { get; set; }

        public int Amount { get; set; }

        public string PaycodeToken { get; set; }
    }
}