using System.Threading.Tasks;
using Server.Dtos.Authentication;
using Server.Models.Agents;

namespace Server.Services.Agent
{
    public interface IAgentService
    {
        Task RegisterAsync(RequestRegistrationDto model);
        // Task<AgentModel> GetAgentById(string id);
        bool VerifyPassword(string password, string hashedPassword);
        Task<AgentModel> GetAgentByPhoneNumberAsync(string phoneNumber);
    }
}