using System;
using System.ComponentModel.DataAnnotations;

namespace EShop.Web.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Product name is required")]
        [StringLength(255)]
        [Display(Name = "Product Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Display(Name = "Unit Price")]
        public double UnitPrice { get; set; }

        [Required(ErrorMessage = "Stock value is required")]
        [Display(Name = "Quantity")]
        public int Stock { get; set; }

        [Display(Name = "Vat(%)")]
        public int Vat { get; set; }

        [Required(ErrorMessage = "Buyform is required")]
        [Display(Name = "Source")]
        public EmportType BuyFrom { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Purchase Date")]
        public DateTime PurchaseDate { get; set; }
    }
}