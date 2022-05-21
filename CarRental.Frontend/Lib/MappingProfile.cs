using System.Collections.Generic;
using AutoMapper;
namespace CarRental.Frontend.Lib
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            SourceMemberNamingConvention = new LowerUnderscoreNamingConvention();
            DestinationMemberNamingConvention = new PascalCaseNamingConvention();

            //CreateMap<StoreInfoModel, MerchantDomain>().ReverseMap();
        }
    }
}