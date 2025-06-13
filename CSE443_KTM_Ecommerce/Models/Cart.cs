using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSE443_KTM_Ecommerce.Models
{
    public class Cart
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime? UpdatedAt { get; set; }


        public int UserId { get; set; }

        public User User { get; set; }
        public ICollection<CartItem>  CartItems { get; set; }=  new List<CartItem>();
        public decimal TotalPrice => CartItems.Sum(item => item.Price * item.Quantity);
    }
}
