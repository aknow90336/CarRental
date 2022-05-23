namespace CarRental.Service
{
    public interface IVerifyService
    {
        void VerifySend(string phone);

        string VerifyPhone(uint id, string code);
    }
}