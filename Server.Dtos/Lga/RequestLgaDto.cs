using System.ComponentModel.DataAnnotations;

namespace Server.Dtos.Lga
{
    public class RequestLgaDto
    {
        [Required]
        public string StateId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}