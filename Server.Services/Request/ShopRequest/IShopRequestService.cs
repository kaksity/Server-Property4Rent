using System.Threading.Tasks;
using Server.Dtos.Request.ShopRequest;

namespace Server.Services.Request.ShopRequest
{
    public interface IShopRequestService
    {
         Task AddShopRequestAsync(CreateShopRequestDto dto);
    }
}