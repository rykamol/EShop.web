﻿using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EShop.Web.Models
{
    public class EshopDbContext : IdentityDbContext<ApplicationUser>
    {
        public EshopDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Product> Products { get; set; }

        public static EshopDbContext Create()
        {
            return new EshopDbContext();
        }
    }
}