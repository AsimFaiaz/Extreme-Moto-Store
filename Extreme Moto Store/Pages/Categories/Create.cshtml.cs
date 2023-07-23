using Extreme_Moto_Store.Data;
using Extreme_Moto_Store.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Extreme_Moto_Store.Pages.Categories
{
    public class CreateModel : PageModel
    {

        private readonly ApplicationDbContext _db;
        [BindProperty]

        public Category Category { get; set; }

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }


        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            if (Category.name == Category.displayOrder.ToString())
            {
                ModelState.AddModelError("Category.name", "Display Order and Name can't be same");
            }

            if(ModelState.IsValid) 
            {
                await _db.Category.AddAsync(Category);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }

            return Page();
       
        }
    }

}




