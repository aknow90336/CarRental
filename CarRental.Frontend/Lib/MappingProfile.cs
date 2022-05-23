using System.Collections.Generic;
using AutoMapper;
using CarRental.Domain.User;
using CarRental.DataAccess.DB.CarDB;

namespace CarRental.Frontend.Lib
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            SourceMemberNamingConvention = new LowerUnderscoreNamingConvention();
            DestinationMemberNamingConvention = new PascalCaseNamingConvention();

            CreateMap<UserDomain, User>().ReverseMap();
        }
    }
}