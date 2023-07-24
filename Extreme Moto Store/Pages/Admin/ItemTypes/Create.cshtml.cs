using Extreme_Moto_Store.DataAccess.Data;
using Extreme_Moto_Store.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Extreme_Moto_Store.Pages.Admin.ItemTypes
{
    public class CreateModel : PageModel
    {

        private readonly ApplicationDbContext _db;
        [BindProperty]

        public ItemType ItemType { get; set; }

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }


        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid) 
            {
                await _db.ItemType.AddAsync(ItemType);
                await _db.SaveChangesAsync();
                TempData["success"] = "";
                return RedirectToPage("Index");
            }

            return Page();
       
        }
    }

}




