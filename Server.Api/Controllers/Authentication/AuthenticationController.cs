using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Server.Dtos.Authentication;
using Server.Models.General;
using Server.Services.Agent;
using Server.Services.Authentication;

namespace Server.Api.Controllers.Authentication
{
    [ApiController]
    [Route("api/v1/authentication")]
    public class AuthenticationController:ControllerBase
    {
        private readonly IAgentService _agentService;
        private readonly IAuthenticationService _authenticationService;
        public AuthenticationController(IAgentService agentService, IAuthenticationService authenticationService)
        {
            _agentService = agentService;
            _authenticationService = authenticationService;
        }
        [HttpPost("login")]
        public async Task<IActionResult> PostLogin([FromBody] RequestLoginDto dto){
            if(ModelState.IsValid == false){
                return BadRequest(ModelState);
            }
            
            var agent = await _agentService.GetAgentByPhoneNumberAsync(dto.PhoneNumber);

            if(agent == null){
                return BadRequest(new ServiceResponseWithoutData{
                    StatusCode = 400,
                    Success = false,
                    Message = "Incorrect Login Credentials"
                });
            }

            if(_agentService.VerifyPassword(dto.Password,agent.Password) == false){
                return BadRequest(new ServiceResponseWithoutData{
                    StatusCode = 400,
                    Success = false,
                    Message = "Incorrect Login Credentials"
                });
            }
            var response = new ServiceReponse<ResponseLoginDto>(){
                Success = true,
                StatusCode = 200,
                Message = "Log In was successful",
                Data = new ResponseLoginDto{
                    Token = _authenticationService.GenerateJWTToken(agent.AgentId)
                }
            };
            return Ok(response);
        }

        [HttpPost("register")]
        public async Task<IActionResult> PostRegister([FromBody] RequestRegistrationDto dto){

            
            
            if(ModelState.IsValid == false){
                return BadRequest(ModelState);
            }
            
            
            //Check if the User with this Email Address exist
            var agent = await _agentService.GetAgentByPhoneNumberAsync(dto.PhoneNumber);
                        
            if(agent != null){
                ModelState.AddModelError("PhoneNumber","Phone Number already exist");
                
                return BadRequest(new ServiceResponseWithoutData{
                    Success = false,
                    StatusCode = 400,
                    Message = "Phone Number already exist"
                });
            }

            //Register the User
            await _agentService.RegisterAsync(dto);

            return Ok(new ServiceResponseWithoutData{
                Success = true,
                StatusCode = 201,
                Message = "Agent account was created successfully"
            });
        }
    }
}
