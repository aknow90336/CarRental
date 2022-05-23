using System.Collections.Generic;
using CarRental.DataAccess.DB.CarDB;

namespace CarRental.DataAccess.Interface
{
    public interface IVerifyRepository
    {
        List<Verify> GetVerifyByPhone(string phone);
        
        void AddVerify(Verify verify);

        void UpdateVerify(Verify verify);
    }
}