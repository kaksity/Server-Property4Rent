using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Server.Dtos.House;
using Server.Models.General;
using Server.Models.House;
using Server.Services.House;

namespace Server.Api.Controllers.House
{
    [ApiController]
    [Route("api/v1/house-types")]
    public class HouseTypesController : ControllerBase
    {
        private readonly IHouseTypeService _houseTypeService;
        public HouseTypesController(IHouseTypeService houseTypeService)
        {
            _houseTypeService = houseTypeService;
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponseWithoutData>> CreateNewHouseType(CreateHouseTypeDto dto)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest();
            }

            await _houseTypeService.CreateHouseTypeAsync(dto);
            return Ok(new ServiceResponseWithoutData{
                StatusCode = 200,
                Success = true,
                Message = "House type record was created successfully"
            });
        }

        [HttpGet]
        public async Task<ActionResult<ServiceReponse<IEnumerable<ReadHouseTypeDto>>>> GetAllHouseTypes()
        {
            return Ok(new ServiceReponse<IEnumerable<ReadHouseTypeDto>> {
                Success = true,
                StatusCode = 200,
                Message = "Retrived house types record",
                Data = await _houseTypeService.GetAllHouseTypesAsync()
            });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponseWithoutData>> DeleteHouseType(string id){

            var houseType = await _houseTypeService.GetHouseTypeByIdAsync(id);
            
            if (houseType == null)
            {
                return NotFound(new ServiceResponseWithoutData{
                StatusCode = 404,
                Success = false,
                Message = "House type record does not exist"
            });
            }

            await _houseTypeService.DeleteHouseTypeAsync(id);
            return Ok(new ServiceResponseWithoutData{
                StatusCode = 200,
                Success = true,
                Message = "House type record was deleted successfully"
            });
        }
    }
}