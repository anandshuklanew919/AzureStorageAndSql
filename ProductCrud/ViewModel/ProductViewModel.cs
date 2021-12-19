using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductCrud.ViewModel
{
    public class ProductViewModel
    {
        public ProductViewModel()
        {

        }

        [Required(ErrorMessage = "Please enter Product name"), Display(Name = "Product Name")]
        public string ProductName { get; set; }
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter Product category")]
        public string Category { get; set; }
        [Required(ErrorMessage = "Please enter Product price"), Display(Name = "Price/piece")]
        public int Price { get; set; }
        [Required(ErrorMessage = "Please enter Product quantity")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Please Enter Description")]
        [Column(TypeName = "varchar(500)")]
        public string Description { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Please upload file"), Display(Name = "Product image")]
        public IFormFile file { get; set; }
    }
}
