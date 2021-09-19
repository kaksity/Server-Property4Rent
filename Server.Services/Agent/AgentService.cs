using System;
using System.Threading.Tasks;
using Server.DataAccess.Agent;
using Server.Dtos.Authentication;
using Server.Models.Agents;

namespace Server.Services.Agent
{
    public class AgentService : IAgentService
    {
        private readonly IAgentRepository _agentRepository;
        public AgentService(IAgentRepository agentRepository)
        {
            _agentRepository = agentRepository;
        }

        public async Task<AgentModel> GetAgentByPhoneNumberAsync(string phoneNumber)
        {
            return await _agentRepository.GetAgentByPhoneNumber(phoneNumber);
        }

        // public Task<AgentModel> GetAgentById(string id)
        // {
        //     throw new System.NotImplementedException();
        // }

        // public Task<AgentModel> GetAgentByPhoneNumber(string phoneNumber)
        // {
        //     throw new System.NotImplementedException();
        // }
        public async Task RegisterAsync(RequestRegistrationDto model)
        {
            string agentModelId = Guid.NewGuid().ToString();
            string agentBiodeDetailId = Guid.NewGuid().ToString();

            var agent = new AgentModel(){
                AgentId = agentModelId,
                PhoneNumber = model.PhoneNumber,
                Password = BCrypt.Net.BCrypt.HashPassword(model.Password),
                IsDeleted = false,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            var agentBioDetail = new AgentBioDetailModel(){
                AgentBioDetailId = agentBiodeDetailId,
                AgentId = agentModelId,
                FullName = model.FullName.ToUpper(),
                IsDeleted = false,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            await _agentRepository.CreateAgent(agent,agentBioDetail);
        }

        public bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password,hashedPassword);
        }
    }
}