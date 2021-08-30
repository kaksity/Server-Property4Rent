using System.Threading.Tasks;
using Server.Models.Agents;

namespace Server.DataAccess.Agent
{
    public interface IAgentRepository
    {
        Task CreateAgent(AgentModel agentModel, AgentBioDetailModel agentBioDetailModel);
        
        //Task<AgentModel> GetAgentById(string id);
        Task<AgentModel> GetAgentByPhoneNumber(string phoneNumber);
        
    }
}