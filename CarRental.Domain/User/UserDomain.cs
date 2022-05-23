namespace CarRental.Domain.User
{
    public class UserDomain
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool? IsPhoneVerify { get; set; }
    }
}