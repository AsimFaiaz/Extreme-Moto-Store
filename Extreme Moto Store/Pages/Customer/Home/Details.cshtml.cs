using Extreme_Moto_Store.DataAccess.Repository.iRepository;
using Extreme_Moto_Store.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace Extreme_Moto_Store.Pages.Customer.Home
{
	[Authorize]
    public class DetailsModel : PageModel
    {
		private readonly IUnitOfWork _unitOfWork;

		public DetailsModel(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		[BindProperty]
		public ShoppingCart ShoppingCart { get; set; }

		public void OnGet(int id)
		{
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);


			ShoppingCart = new()
			{
				ApplicationUserId = claim.Value,
				Product = _unitOfWork.Product.GetFirstOrDefault(u => u.Id == id, includeProperties: "Category,ItemType"), //Load the product 
				ProductId = id
			};
			
		}

        public IActionResult OnPost()
        {
			if(ModelState.IsValid)
			{
				//Chking validitity for the same product and the same user
				ShoppingCart shoppingCartFromDb = _unitOfWork.ShoppingCart.GetFirstOrDefault(
					filter: u=>u.ApplicationUserId == ShoppingCart.ApplicationUserId && u.ProductId == ShoppingCart.ProductId);
				 
				if(shoppingCartFromDb == null) 
				{
					_unitOfWork.ShoppingCart.Add(ShoppingCart);
					_unitOfWork.Save();
				}
				else
				{
					_unitOfWork.ShoppingCart.IncrementCount(shoppingCartFromDb, ShoppingCart.Count);
				}

                return RedirectToPage("Index");
            }

			return Page();
        }
    }
}
