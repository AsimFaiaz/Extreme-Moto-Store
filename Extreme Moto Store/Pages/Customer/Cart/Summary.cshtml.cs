using Extreme_Moto_Store.DataAccess.Repository.iRepository;
using Extreme_Moto_Store.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace Extreme_Moto_Store.Pages.Customer.Cart
{
    [Authorize]
    public class SummaryModel : PageModel
    {
        public IEnumerable<ShoppingCart> ShoppingCartList { get; set; }

        public OrderHeader orderHeader { get; set; }

        private readonly IUnitOfWork _unitOfWork;

        public SummaryModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            orderHeader = new OrderHeader();
        }

        public void OnGet()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            if (claim != null)
            {
                ShoppingCartList = _unitOfWork.ShoppingCart.GetAll(filter: u => u.ApplicationUserId == claim.Value, includeProperties: "Product,Product.Category,Product.ItemType"); //No space after includeProps and case sens

                //Cart total
                foreach (var cartItem in ShoppingCartList)
                {
                    orderHeader.OrderTotal += (cartItem.Product.Price * cartItem.Count);
                }

                ApplicationUser applicationUser = _unitOfWork.ApplicationUser.GetFirstOrDefault(u=>u.Id == claim.Value);
                orderHeader.PickUpName = applicationUser.FirstName + " " + applicationUser.LastName;
                orderHeader.PhoneNumber = applicationUser.PhoneNumber;
            }
        }
    }
}
