using Extreme_Moto_Store.Data;
using Extreme_Moto_Store.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Extreme_Moto_Store.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IEnumerable <Category> Categories { get; set; }

        public IndexModel(ApplicationDbContext db)
        {
                _db = db;
        }


        public void OnGet()
        {
            Categories = _db.Category;
        }
    }
}
