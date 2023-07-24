using Extreme_Moto_Store.DataAccess.Data;
using Extreme_Moto_Store.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Extreme_Moto_Store.Pages.Admin.ItemTypes
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]

        public ItemType ItemType { get; set; }

        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }


        public void OnGet(int id)
        {
            ItemType = _db.ItemType.Find(id);
        }
        public async Task<IActionResult> OnPost()
        {
            
                var itemFromDb = _db.ItemType.Find(ItemType.Id);

                if(itemFromDb != null) 
                {
                    _db.ItemType.Remove(itemFromDb);
                    await _db.SaveChangesAsync();
                TempData["error"] = "";
                return RedirectToPage("Index");
                 }

            return Page();

        }
    }
}
