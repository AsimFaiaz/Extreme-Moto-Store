using Extreme_Moto_Store.DataAccess.Repository.iRepository;
using Extreme_Moto_Store.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Extreme_Moto_Store.Pages.Customer.Home
{
	[Authorize]
    public class DetailsModel : PageModel
    {
		private readonly IUnitOfWork _iUnitOfWork;

		public DetailsModel(IUnitOfWork unitOfWork)
		{
			_iUnitOfWork = unitOfWork;
		}

		[BindProperty]
		public ShoppingCart ShoppingCart { get; set; }

		public void OnGet(int id)
		{
			ShoppingCart = new()
			{
				Product = _iUnitOfWork.Product.GetFirstOrDefault(u => u.Id == id, includeProperties: "Category,ItemType") //Load the product 
			};
			
		}
	}
}
