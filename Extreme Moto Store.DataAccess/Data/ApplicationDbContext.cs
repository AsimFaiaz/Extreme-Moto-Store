using Extreme_Moto_Store.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Extreme_Moto_Store.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        //Migrations: PMC > add-migration addCategoryToDb
        //update-database
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options)   //Shortcut: ctor tab
        {
            
        }

        public DbSet<Category> Category { get; set; }
        public DbSet<ItemType> ItemType { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<OrderHeader> OrderHeader { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
    }
}
