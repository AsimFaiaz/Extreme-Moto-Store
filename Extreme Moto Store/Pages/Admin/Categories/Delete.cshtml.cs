using Extreme_Moto_Store.DataAccess.Data;
using Extreme_Moto_Store.DataAccess.Repository.iRepository;
using Extreme_Moto_Store.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Extreme_Moto_Store.Pages.Admin.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public Category Category { get; set; }

        public DeleteModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public void OnGet(int id)
        {
            Category = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == id);
        }
        public async Task<IActionResult> OnPost()
        {
            
                var categoryFromDb = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == Category.Id);

                if(categoryFromDb != null) 
                {
                    _unitOfWork.Category.Remove(categoryFromDb);
                    _unitOfWork.Save();
                TempData["error"] = "";
                return RedirectToPage("Index");
                 }

            return Page();

        }
    }
}
