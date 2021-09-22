using System.Collections.Generic;
using System.Threading.Tasks;
using Server.Dtos.Request.ShopRequest;
using Server.Models.Request;

namespace Server.Services.Request.ShopRequest
{
    public interface IShopRequestService
    {
         Task AddShopRequestAsync(CreateShopRequestDto dto);
         Task<IEnumerable<ReadDetailShopRequestDto>> GetAllShopRequestsAsync();
         Task<ReadDetailShopRequestDto> GetShopRequestAsync(string shopRequestId);
    }
}