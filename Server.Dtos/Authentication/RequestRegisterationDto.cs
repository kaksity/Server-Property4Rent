using System.ComponentModel.DataAnnotations;

namespace Server.Dtos.Authentication
{
    public class RequestRegistrationDto
    {
        [Required(ErrorMessage = "Full Name is required")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        public string PhoneNumber { get; set; }
        
        [Required(ErrorMessage = "Password is required")]
        [MinLength(8,ErrorMessage = "Password must be 8 or more characters")]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Confirm Password must match Password")]
        public string ConfirmPassword { get; set; }
    }
}