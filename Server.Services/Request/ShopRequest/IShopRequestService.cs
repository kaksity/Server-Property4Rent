using System.Collections.Generic;
using System.Threading.Tasks;
using Server.Dtos.Request.ShopRequest;
using Server.Models.Request;

namespace Server.Services.Request.ShopRequest
{
    public interface IShopRequestService
    {
         Task AddShopRequestAsync(CreateShopRequestDto dto);
         Task<IEnumerable<ShopRequestModel>> GetAllShopRequestsAsync();
         Task<ShopRequestModel> GetShopRequestAsync(string shopRequestId);
    }
}