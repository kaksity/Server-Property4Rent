using System.Threading.Tasks;
using Server.Models.Request;

namespace Server.DataAccess.Request.ShopRequest
{
    public interface IShopRequestRepository
    {
         Task AddShopRequestAsync(ShopRequestModel model);
    }
}