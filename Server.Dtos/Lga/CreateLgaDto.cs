using System.ComponentModel.DataAnnotations;

namespace Server.Dtos.Lga
{
    public class CreateLgaDto
    {
        [Required]
        public string StateId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}