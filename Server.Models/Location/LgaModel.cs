using System;

namespace Server.Models.Location
{
    public class LgaModel
    {
        public string Id { get; set; }
        public string StateId { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}