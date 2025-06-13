using CSE443_KTM_Ecommerce.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSE443_KTM_Ecommerce.Models
{
    public class Order
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        public OrderStatus Status { get; set; } = OrderStatus.PENDING;

        public double OrderTotalPrice { get; set; }


        public int UserId { get; set; }

        public User User { get; set; }
        public int? CouponId { get; set; }

        public Coupon? Coupon { get; set; }
        public int DeliveryId { get; set; }
        public Delivery? Delivery { get; set; }
        // Optional -  The Address can be retrieved from Address Field of Entity User
        // For case :  User didn't enter their Address or Personal Information
        public string? DeliveryAddress { get; set; }

        public Payment Payment { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? CanceledAt { get; set; }
        public DateTime? CompletedAt {get;set;}
        public DateTime? DeliveredAt { get; set; }

        // Add navigation property for OrderDetails
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
