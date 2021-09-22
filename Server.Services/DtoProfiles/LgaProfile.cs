using AutoMapper;
using Server.Dtos.Lga;
using Server.Models.Location;

namespace Server.Services.DtoProfiles
{
    public class LgaProfile:Profile
    {
        public LgaProfile()
        {
            CreateMap<LgaModel,ReadLgaDto>();
            CreateMap<CreateLgaDto,LgaModel>();
        }
    }
}