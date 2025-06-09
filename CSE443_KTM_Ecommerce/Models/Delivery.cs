using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSE443_KTM_Ecommerce.Models
{
    public class Delivery
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Delivery method name is required")]
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        [Range(0, 1000, ErrorMessage = "Delivery fee must be between 0 and 1000")]
        public decimal DeliveryFees { get; set; }
        public ICollection<Order> Orders { get; set; } =  new List<Order>();    
    }
}
