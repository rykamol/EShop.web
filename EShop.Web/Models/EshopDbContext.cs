using System.Data.Entity;
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
        public DbSet<SaleProduct> SaleProducts { get; set; }
        
        public static EshopDbContext Create()
        {
            return new EshopDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<SaleProduct>().HasRequired(c => c.Product).WithMany().WillCascadeOnDelete(false);
        }
    }
}