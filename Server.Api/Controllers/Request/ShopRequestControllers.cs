using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Server.Dtos.Request.ShopRequest;
using Server.Models.General;
using Server.Models.Request;
using Server.Services.Request.ShopRequest;

namespace Server.Api.Controllers.Request
{
    [ApiController]
    [Route("api/v1/requests/shops")]
    public class ShopRequestControllers:ControllerBase
    {
        private readonly IShopRequestService _shopRequestService;

        public ShopRequestControllers(IShopRequestService shopRequestService)
        {
            _shopRequestService = shopRequestService;    
        }

        [HttpGet]
        public async Task<ActionResult<ServiceReponse<IEnumerable<ReadDetailShopRequestDto>>>> GetAllShopRequests()
        {
            return Ok(new ServiceReponse<IEnumerable<ReadDetailShopRequestDto>>{
                StatusCode = 200,
                Success = true,
                Message = "Retrived Shop Requests records",
                Data = await _shopRequestService.GetAllShopRequestsAsync()
            });
        }
        [HttpGet("{shopRequestId}")]
        public async Task<ActionResult<ServiceReponse<ReadDetailShopRequestDto>>> GetShopRequest(string shopRequestId){
            var shopRequest = await _shopRequestService.GetShopRequestAsync(shopRequestId);

            if(shopRequest == null)
            {
                return NotFound();
            }
            return Ok(new ServiceReponse<ReadDetailShopRequestDto>{
                StatusCode = 200,
                Message = "Retrived Shop Request record",
                Success = true,
                Data = shopRequest
            });
            
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponseWithoutData>> CreateShopRequest([FromBody] CreateShopRequestDto dto){
            if(ModelState.IsValid == false){
                return BadRequest(ModelState);
            }
            await _shopRequestService.AddShopRequestAsync(dto);
            return Ok(new ServiceResponseWithoutData{
                Success=true,
                StatusCode = 201,
                Message="Shop Request was successful",
            });
        }
    }
}