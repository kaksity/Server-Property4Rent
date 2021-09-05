using System.Collections.Generic;
using System.Threading.Tasks;
using Server.Dtos.House;
using Server.Models.House;

namespace Server.Services.House
{
    public interface IHouseTypeService
    {
         Task CreateHouseTypeAsync(RequestHouseTypeDto dto);
         Task<HouseTypeModel> GetHouseTypeByIdAsync(string id);
         Task<IEnumerable<HouseTypeModel>> GetAllHouseTypesAsync();
         Task DeleteHouseTypeAsync(string id);
    }
}