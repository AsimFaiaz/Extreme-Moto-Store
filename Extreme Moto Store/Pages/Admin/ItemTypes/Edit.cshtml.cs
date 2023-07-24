using Extreme_Moto_Store.DataAccess.Data;
using Extreme_Moto_Store.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Extreme_Moto_Store.Pages.Admin.ItemTypes
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]

        public ItemType ItemType { get; set; }

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }


        public void OnGet(int id)
        {
            ItemType = _db.ItemType.Find(id);
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                _db.ItemType.Update(ItemType);
                await _db.SaveChangesAsync();
                TempData["warning"] = "";
                return RedirectToPage("Index");
            }

            return Page();

        }
    }
}
