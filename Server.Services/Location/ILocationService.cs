using System.Collections.Generic;
using System.Threading.Tasks;
using Server.Dtos.Lga;
using Server.Dtos.State;
using Server.Models.Location;

namespace Server.Services.Location
{
    public interface ILocationService
    {
        Task CreateStateAsync(RequestStateDto dto);
        Task<StateModel> GetStateByNameAsync(string stateName);
        Task<StateModel> GetStateByIdAsync(string id);
        Task<IEnumerable<StateModel>> GetAllStatesAsync();
        Task DeleteStateAsync(string id);
        Task CreateLgaAsync(CreateLgaDto dto);
        Task<IEnumerable<ReadLgaDto>> GetAllLgasAsync(string stateId);
        Task<ReadLgaDto> GetLgaByIdAsync(string id);
        Task DeleteLgaAsync(string id);
    }
}