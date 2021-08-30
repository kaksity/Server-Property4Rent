using System;

namespace Server.Models.Agents
{
    public class AgentDocumentModel
    {
        public string Id { get; set; }
        public string AgentId { get; set; }
        public string DocumentPath { get; set; }
        public string Side { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}