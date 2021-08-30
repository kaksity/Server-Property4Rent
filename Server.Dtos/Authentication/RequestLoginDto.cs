using System.ComponentModel.DataAnnotations;

namespace Server.Dtos.Authentication
{
    public class RequestLoginDto
    {
        [Required(ErrorMessage = "Phone Number is required")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}