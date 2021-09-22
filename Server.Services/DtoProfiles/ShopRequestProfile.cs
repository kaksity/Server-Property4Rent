
using AutoMapper;
using Server.Dtos.Request.ShopRequest;
using Server.Models.Request;

namespace Server.Services.DtoProfiles
{
    public class ShopRequestProfile : Profile
    {
        public ShopRequestProfile()
        {
            CreateMap<ShopRequestModel,ReadDetailShopRequestDto>();
        }
    }
}