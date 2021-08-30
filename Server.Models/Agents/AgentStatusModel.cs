using System;

namespace Server.Models.Agents
{
    public class AgentStatusModel
    {
        public string Id { get; set; }
        public string AgentId { get; set; }
        public bool IsVerified { get; set; }
        public bool IsRejected { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}