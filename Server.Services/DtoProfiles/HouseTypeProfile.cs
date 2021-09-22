using AutoMapper;
using Server.Dtos.House;
using Server.Models.House;
namespace Server.Services.DtoProfiles
{
    public class HouseTypeProfile : Profile
    {
        public HouseTypeProfile()
        {
            CreateMap<HouseTypeModel,ReadHouseTypeDto>();    
        }
    }
}