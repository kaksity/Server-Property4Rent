using System;
using System.Threading.Tasks;
using Server.DataAccess.Request.ShopRequest;
using Server.Dtos.Request.ShopRequest;
using Server.Models.Request;

namespace Server.Services.Request.ShopRequest
{
    public class ShopRequestService : IShopRequestService
    {
        private readonly IShopRequestRepository _shopRequestRepository;
        public ShopRequestService(IShopRequestRepository shopRequestRepository)
        {
            _shopRequestRepository = shopRequestRepository;
        }

        public async Task AddShopRequestAsync(CreateShopRequestDto dto)
        {
            var shopRequest = new ShopRequestModel{
                ShopRequestId = Guid.NewGuid().ToString(),
                FullName = dto.FullName.ToUpper(),
                PhoneNumber = dto.PhoneNumber,
                ShopNearestLandMark = dto.ShopNearestLandMark,
                StateId = dto.StateId,
                LgaId = dto.LgaId,
                Description = dto.Description,
                MinPrice = dto.MinPrice,
                MaxPrice = dto.MaxPrice,
                IsDeleted = false,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };    

            await _shopRequestRepository.AddShopRequestAsync(shopRequest);
        }
    }
}