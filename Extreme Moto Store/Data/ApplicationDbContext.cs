using Extreme_Moto_Store.Model;
using Microsoft.EntityFrameworkCore;

namespace Extreme_Moto_Store.Data
{
    public class ApplicationDbContext : DbContext
    {
        //Migrations: PMC > add-migration addCategoryToDb
        //update-database
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options)   //Shortcut: ctor tab
        {
            
        }

        public DbSet<Category> Category { get; set; }
    }
}
