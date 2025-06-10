using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSE443_KTM_Ecommerce.Models
{
    public class ProductImage
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string ImagePath { get; set; }

        public int DisplayOrder { get; set; } = 0;

        [Required]
        public int ProductId { get; set; }

        public Product Product { get; set; }
    }
}
