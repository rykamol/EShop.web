using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EShop.Web.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Product name is required")]
        [StringLength(255)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Price is required")]
        public double UnitPrice { get; set; }

        [Required(ErrorMessage = "Stock value is required")]
        public int Stock { get; set; }

        public int Vat { get; set; }

        [Required(ErrorMessage = "Buyform is required")]
        public EmportType BuyFrom { get; set; }
    }
}