using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;

namespace CSE443_KTM_Ecommerce.Models
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage ="Category  Name Must Not Be Null")]
        public int Name { get; set; }
        public string? Description { get; set; }
        public string?  ImagePath { get; set; }
    
        public ICollection<Product> Products { get; set; } = new List<Product>();


        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime?UpdatedAt { get; set; }
    }
}
