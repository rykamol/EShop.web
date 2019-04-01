﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using EShop.Web.Models;

namespace EShop.Web.ViewModels
{
    public class SaleProductViewModel
    {

        [Required]
        [Display(Name = "Product")]
        public int ProductId { get; set; }

        public Product Product { get; set; }

        [DataType(DataType.Date)]
        public DateTime SaleDate { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        [Display(Name = "Total Price")]
        public double TotalPrice { get; set; }
    }
}