using Extreme_Moto_Store.Models;
using Microsoft.EntityFrameworkCore;

namespace Extreme_Moto_Store.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        //Migrations: PMC > add-migration addCategoryToDb
        //update-database
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options)   //Shortcut: ctor tab
        {
            
        }

        public DbSet<Category> Category { get; set; }
        public DbSet<ItemType> ItemType { get; set; }
        public DbSet<Product> Product { get; set; }
    }
}
