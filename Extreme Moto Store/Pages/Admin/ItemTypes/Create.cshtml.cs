using Extreme_Moto_Store.DataAccess.Data;
using Extreme_Moto_Store.DataAccess.Repository.iRepository;
using Extreme_Moto_Store.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Extreme_Moto_Store.Pages.Admin.ItemTypes
{
    [BindProperties]   //Important, Null exp will be given if missing
    public class CreateModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public ItemType ItemType { get; set; }

        public CreateModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid) 
            {
                _unitOfWork.ItemType.Add(ItemType);
                _unitOfWork.Save();
                TempData["success"] = "";
                return RedirectToPage("Index");
            }
            return Page();
       
        }
    }

}




