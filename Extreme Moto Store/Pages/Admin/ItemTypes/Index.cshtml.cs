using Extreme_Moto_Store.DataAccess.Data;
using Extreme_Moto_Store.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Extreme_Moto_Store.Pages.Admin.ItemTypes
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IEnumerable <ItemType> ItemTypes { get; set; }

        public IndexModel(ApplicationDbContext db)
        {
                _db = db;
        }


        public void OnGet()
        {
            ItemTypes = _db.ItemType;
        }
    }
}
