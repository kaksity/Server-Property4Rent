using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Server.Dtos.Lga;
using Server.Models.General;
using Server.Models.Location;
using Server.Services.Location;

namespace Server.Api.Controllers.Location
{
    [ApiController]
    [Route("api/v1/lgas")]
    public class LgasController : ControllerBase
    {
        private readonly ILocationService _locationService;
        public LgasController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateLgaAsync(RequestLgaDto dto){
            if (ModelState.IsValid == false)
            { 
              return BadRequest();  
            }

            await _locationService.CreateLgaAsync(dto);

            return Ok(new ServiceResponseWithoutData{
                StatusCode = 200,
                Success = true,
                Message = "Lga record was created successfully",
            });
        }
        [HttpGet("{stateId}")]
        public async Task<ActionResult<ServiceReponse<IEnumerable<ReadLgaDto>>>> GetAllLgas(string stateId){
            return Ok(new ServiceReponse<IEnumerable<ReadLgaDto>>{
                StatusCode = 200,
                Success = true,
                Message = "Retrived lga records",
                Data = await _locationService.GetAllLgasAsync(stateId)
            });
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLga(string id){
            
            var lga = await _locationService.GetLgaByIdAsync(id);
            
            if (lga == null)
            {
                return BadRequest(new ServiceResponseWithoutData{
                    StatusCode = 400,
                    Success = false,
                    Message = "Lga record does not exist"
                });
            }
            
            await _locationService.DeleteLgaAsync(id);

            return Ok(new ServiceResponseWithoutData{
                StatusCode = 400,
                Success = false,
                Message = "Lga record was deleted successfully"
            });
        }
    }
}