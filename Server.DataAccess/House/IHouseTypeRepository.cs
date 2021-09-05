using System.Collections.Generic;
using System.Threading.Tasks;
using Server.Models.House;

namespace Server.DataAccess.House
{
    public interface IHouseTypeRepository
    {
         Task CreateHouseTypeAsync(HouseTypeModel model);
         Task<HouseTypeModel> GetHouseTypeByIdAsync(string id);
         Task<IEnumerable<HouseTypeModel>> GetAllHouseTypesAsync();
         Task DeleteHouseTypeAsync(string id);
    }
}