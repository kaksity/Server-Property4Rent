using System;

namespace Server.Models.Agents
{
    public class AgentDocumentModel
    {
        public string AgentDocumentId { get; set; }
        public string AgentId { get; set; }
        public string DocumentPath { get; set; }
        public string DocumentType { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}