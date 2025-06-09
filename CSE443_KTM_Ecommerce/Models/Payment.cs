using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSE443_KTM_Ecommerce.Models
{
    public class Payment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int OrderId { get; set; }

        [ForeignKey("OrderId")]
        public Order Order { get; set; }

        [Required]
        public string Method { get; set; } // e.g., "Credit Card", "PayPal", "COD"

        [Column(TypeName = "decimal(10,2)")]
        public decimal Amount { get; set; }

        public string PaymentStatus { get; set; } // e.g., "Paid", "Pending", "Failed"

        public DateTime PaymentDate { get; set; }
    }
}
