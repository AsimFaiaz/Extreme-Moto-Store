using Extreme_Moto_Store.DataAccess.Repository;
using Extreme_Moto_Store.DataAccess.Repository.iRepository;
using Extreme_Moto_Store.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Cryptography.Xml;

namespace Extreme_Moto_Store.Pages.Customer.Home
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Product> ProductList { get; set; }
        public IEnumerable<Category> CategoryList { get; set; }

        public void OnGet()
        {
            ProductList  = _unitOfWork.Product.GetAll(includeProperties: "Category,ItemType") ;
            CategoryList = _unitOfWork.Category.GetAll(orderby: u => u.OrderBy(c=>c.DisplayOrder));

        }
    }
}
