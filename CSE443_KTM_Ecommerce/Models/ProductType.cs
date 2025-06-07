using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSE443_KTM_Ecommerce.Models
{
    public class ProductType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage= "Product Type Name Must Not Be Null")]
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; } =  new List<Product>();
    }
}
