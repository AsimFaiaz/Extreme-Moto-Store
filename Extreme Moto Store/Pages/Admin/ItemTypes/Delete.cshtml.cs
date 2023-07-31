using Extreme_Moto_Store.DataAccess.Data;
using Extreme_Moto_Store.DataAccess.Repository.iRepository;
using Extreme_Moto_Store.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Extreme_Moto_Store.Pages.Admin.ItemTypes
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public ItemType ItemType { get; set; }

        public DeleteModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public void OnGet(int id)
        {
            ItemType = _unitOfWork.ItemType.GetFirstOrDefault(u => u.Id == id);
        }
        public async Task<IActionResult> OnPost()
        {

            var itemFromDb = _unitOfWork.ItemType.GetFirstOrDefault(u => u.Id == ItemType.Id);

            if (itemFromDb != null)
            {
                _unitOfWork.ItemType.Remove(itemFromDb);
                _unitOfWork.Save();
                TempData["error"] = "";
                return RedirectToPage("Index");
            }

            return Page();

        }
    }
}
