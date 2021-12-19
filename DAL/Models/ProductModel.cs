using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{

    [Table(name: "product")]
    public class ProductModel
    {
        public ProductModel()
        {
            CreatedDate = DateTime.Now;
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

        [Column(TypeName = "varchar(250)")]
        public string? ImagePath { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string? ImageName { get; set; }

        [Required(ErrorMessage = "Please Enter Description")]
        [Column(TypeName = "varchar(500)")]
        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Please upload file"), Display(Name = "Product image")]
        public IFormFile file { get; set; }
    }
}

