using System;

namespace Server.Models.Document
{
    public class DocumentModel
    {
        public string  Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}