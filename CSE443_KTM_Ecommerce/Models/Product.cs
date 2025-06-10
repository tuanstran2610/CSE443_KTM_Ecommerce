using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSE443_KTM_Ecommerce.Models
{
    public class Product
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Required(ErrorMessage = "Product Name Must Not Be Null")]
        public string Name { get; set; }
        public string Brand { get; set; }


        [Required(ErrorMessage = "Quantity Must Not Be Null")]
        public int Quantity { get; set; } = 0;
        [Required(ErrorMessage = "Price Must Not Be Null")]
        [Column(TypeName ="decimal(10,2)")]
        public decimal Price { get; set; }

        public string Description { get; set; }
        public string? ImagePath { get; set; }
        /// Status of Product:  0 - Stop Selling , 1 - Active Product
        public int Status { get; set; } = 1;

        public int SoldQuantity { get; set; } = 0;


        /// Feature of Product :  true -  Featured Products  , false : No
        public bool Featured { get; set; } = true;
        public string Dimensions { get; set; }
        public string Weight { get; set; }

        
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime? UpdatedAt { get; set; }
     

        public string Size { get; set; }
        public string Fabric { get; set; }
        public string Warranty { get; set; }

        /// Foreign Key 
        /// Set the ProductType into an Entity ( Table) in order  to further have  other product types
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public int ProductTypeId { get; set; }
        public Category Category { get; set; }
        public ProductType ProductType { get; set; }
        public ICollection<ProductImage> ProductImages { get; set; } =  new List<ProductImage>();
        public ICollection<ProductDiscount> ProductDiscounts { get; set; } = new List<ProductDiscount>();
    }
}
