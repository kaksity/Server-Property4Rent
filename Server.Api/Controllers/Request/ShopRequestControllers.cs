using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Server.Dtos.Request.ShopRequest;
using Server.Models.General;
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