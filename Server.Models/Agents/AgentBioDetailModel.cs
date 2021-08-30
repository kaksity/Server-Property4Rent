using System;

namespace Server.Models.Agents
{
    public class AgentBioDetailModel
    {
        public string Id { get; set; }
        public string AgentId { get; set; }
        public string FullName { get; set; }
        public string NIN { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string EmailAddress { get; set; }
        public string ContactAddress { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}