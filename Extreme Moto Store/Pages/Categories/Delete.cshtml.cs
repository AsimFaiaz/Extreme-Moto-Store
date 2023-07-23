using Extreme_Moto_Store.Data;
using Extreme_Moto_Store.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Extreme_Moto_Store.Pages.Categories
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
            
                var categoryFromDb = _db.Category.Find(Category.id);

                if(categoryFromDb != null) 
                {
                    _db.Category.Remove(categoryFromDb);
                    await _db.SaveChangesAsync();
                    return RedirectToPage("Index");
                 }

            return Page();

        }
    }
}
