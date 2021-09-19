using System;
namespace Server.Models.Request
{
    public class ShopRequestModel
    {
        public string ShopRequestId { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string ShopNearestLandMark { get; set; }
        public string StateId { get; set; }
        public string LgaId { get; set; }
        public string Description { get; set; }
        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}