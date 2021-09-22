using AutoMapper;
using Server.Dtos.State;
using Server.Models.Location;

namespace Server.Services.DtoProfiles
{
    public class StateProfile:Profile
    {
        public StateProfile()
        {
            CreateMap<StateModel,ReadStateDto>();
        }        
    }
}