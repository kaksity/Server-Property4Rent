using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Server.DataAccess.Request.ShopRequest;
using Server.Dtos.Request.ShopRequest;
using Server.Models.Request;

namespace Server.Services.Request.ShopRequest
{
    public class ShopRequestService : IShopRequestService
    {
        private readonly IShopRequestRepository _shopRequestRepository;
        private readonly IMapper _mapper;
        public ShopRequestService(IShopRequestRepository shopRequestRepository,IMapper mapper)
        {
            _mapper = mapper;
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

        public async Task<IEnumerable<ReadDetailShopRequestDto>> GetAllShopRequestsAsync()
        {
            var shopRequest = await _shopRequestRepository.GetAllShopRequestsAsync();
            return _mapper.Map<IEnumerable<ReadDetailShopRequestDto>>(shopRequest);
        }

        public async Task<ReadDetailShopRequestDto> GetShopRequestAsync(string shopRequestId)
        {
            var shopRequests = await _shopRequestRepository.GetShopRequestAsync(shopRequestId);
            return _mapper.Map<ReadDetailShopRequestDto>(shopRequests);
        }
    }
}