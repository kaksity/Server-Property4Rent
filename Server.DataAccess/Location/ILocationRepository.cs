using System.Collections.Generic;
using System.Threading.Tasks;
using Server.Models.Location;

namespace Server.DataAccess.Location
{
    public interface ILocationRepository
    {
         Task CreateStateAsync(StateModel model);
         Task<StateModel> GetStateByNameAsync(string stateName);
         Task<StateModel> GetStateByIdAsync(string id);
         Task<IEnumerable<StateModel>> GetAllStatesAsync();
         Task DeleteStateAsync(string id);

         Task CreateLgaAsync(LgaModel model);
         Task<IEnumerable<LgaModel>> GetAllLgasAsync(string stateId);
         Task<LgaModel> GetLgaByIdAsync(string id);
         Task DeleteLgaAsync(string id);
         
    }
}