using System.ComponentModel.DataAnnotations;

namespace Server.Dtos.Request.ShopRequest
{
    public class CreateShopRequestDto
    {
        [Required(ErrorMessage = "Full Name is required")]
        public string FullName { get; set; }
        
        [Required(ErrorMessage = "Phone Number is required")]
        public string PhoneNumber { get; set; }
        
        public string ShopNearestLandMark { get; set; }
        [Required(ErrorMessage = "State is required")]
        
        public string StateId { get; set; }
        [Required(ErrorMessage = "Lga is required")]
        public string LgaId { get; set; }
        public string Description { get; set; }

        [Required(ErrorMessage = "Minimun Price is required")]
        public decimal MinPrice { get; set; }
        
        [Required(ErrorMessage = "Maximun Price is required")]
        public decimal MaxPrice { get; set; }
    }
}