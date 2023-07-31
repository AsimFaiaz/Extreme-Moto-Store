using Extreme_Moto_Store.DataAccess.Data;
using Extreme_Moto_Store.DataAccess.Repository.iRepository;
using Extreme_Moto_Store.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Extreme_Moto_Store.Pages.Admin.ItemTypes
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public ItemType ItemType { get; set; }

        public EditModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public void OnGet(int id)
        {
            ItemType = _unitOfWork.ItemType.GetFirstOrDefault(u => u.Id == id);
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.ItemType.Update(ItemType);
                _unitOfWork.Save();
                TempData["warning"] = "";
                return RedirectToPage("Index");
            }

            return Page();

        }
    }
}
