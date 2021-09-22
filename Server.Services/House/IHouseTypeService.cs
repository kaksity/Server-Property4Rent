using System.Collections.Generic;
using System.Threading.Tasks;
using Server.Dtos.House;
using Server.Models.House;

namespace Server.Services.House
{
    public interface IHouseTypeService
    {
         Task CreateHouseTypeAsync(CreateHouseTypeDto dto);
         Task<ReadHouseTypeDto> GetHouseTypeByIdAsync(string id);
         Task<IEnumerable<ReadHouseTypeDto>> GetAllHouseTypesAsync();
         Task DeleteHouseTypeAsync(string id);
    }
}