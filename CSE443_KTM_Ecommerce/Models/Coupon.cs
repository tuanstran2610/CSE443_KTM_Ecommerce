using CSE443_KTM_Ecommerce.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSE443_KTM_Ecommerce.Models
{
    public class Coupon
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   

        public int Id { get; set; }


        [Required]
        public string CouponCode { get; set; }


        public CouponType CouponType { get; set; } = CouponType.PERCENT;

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal CouponMinSpend { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal CouponMaxSpend { get; set; }

        // Number of times of using Coupon for each user -  Customer
        public int CouponCount { get; set; } = 2;

        public CouponStatus CouponStatus { get; set; } = CouponStatus.ACTIVE;
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime? UpdatedAt { get; set; }

        public DateTime? DeletedAt { get; set; }

    }
}
