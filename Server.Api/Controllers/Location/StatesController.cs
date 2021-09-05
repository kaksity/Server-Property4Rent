using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Server.Dtos.State;
using Server.Models.General;
using Server.Models.Location;
using Server.Services.Location;

namespace Server.Api.Controllers.Location
{
    [ApiController]
    [Route("api/v1/states")]
    public class StatesController:ControllerBase
    {
        private readonly ILocationService _locationService;
        
        public StatesController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpPost]
        public async Task<IActionResult> PostNewState(RequestStateDto dto)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest();   
            }
            
            // var state = _locationService.GetStateByNameAsync(dto.Name);

            // if (state != null)
            // {
            //     return BadRequest(new ServiceResponseWithoutData{
            //         StatusCode = 400,
            //         Success = false,
            //         Message = "State with this name already exist"
            //     });
            // }

            await _locationService.CreateStateAsync(dto);

            return Ok(new ServiceResponseWithoutData{
                StatusCode = 200,
                Success = true,
                Message = "State record was created successfully"
            });
        }
        
        [HttpGet]
        public async Task<ActionResult<ServiceReponse<IEnumerable<StateModel>>>> GetAllStates()
        {
            ServiceReponse<IEnumerable<StateModel>> response = new ServiceReponse<IEnumerable<StateModel>>(){
                StatusCode = 200,
                Success = true,
                Message = "Retrieved state records",
                Data = await _locationService.GetAllStatesAsync(),
            };
            return Ok(response);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteState(string id)
        {
            var state = await _locationService.GetStateByIdAsync(id);

            if(state == null){
                return NotFound(new ServiceResponseWithoutData{
                    Success = false,
                    Message = "State record does not exist",
                    StatusCode = 404,
                });
            }

            await _locationService.DeleteStateAsync(id);
            return Ok(new ServiceResponseWithoutData{
                    Success = true,
                    Message = "State record was deleted successfully",
                    StatusCode = 200,
                });
        }
    }
}