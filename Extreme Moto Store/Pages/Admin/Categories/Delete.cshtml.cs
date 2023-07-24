using Extreme_Moto_Store.DataAccess.Data;
using Extreme_Moto_Store.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Extreme_Moto_Store.Pages.Admin.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]

        public Category Category { get; set; }

        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }


        public void OnGet(int id)
        {
            Category = _db.Category.Find(id);
        }
        public async Task<IActionResult> OnPost()
        {
            
                var categoryFromDb = _db.Category.Find(Category.Id);

                if(categoryFromDb != null) 
                {
                    _db.Category.Remove(categoryFromDb);
                    await _db.SaveChangesAsync();
                TempData["error"] = "";
                return RedirectToPage("Index");
                 }

            return Page();

        }
    }
}
