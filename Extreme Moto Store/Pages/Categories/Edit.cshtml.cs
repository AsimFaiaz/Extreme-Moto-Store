using Extreme_Moto_Store.Data;
using Extreme_Moto_Store.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Extreme_Moto_Store.Pages.Categories
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]

        public Category Category { get; set; }

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }


        public void OnGet(int id)
        {
            Category = _db.Category.Find(id);
        }
        public async Task<IActionResult> OnPost()
        {
            if (Category.name == Category.displayOrder.ToString())
            {
                ModelState.AddModelError("Category.name", "Display Order and Name can't be same");
            }

            if (ModelState.IsValid)
            {
                _db.Category.Update(Category);
                await _db.SaveChangesAsync();
                TempData["warning"] = "";
                return RedirectToPage("Index");
            }

            return Page();

        }
    }
}
