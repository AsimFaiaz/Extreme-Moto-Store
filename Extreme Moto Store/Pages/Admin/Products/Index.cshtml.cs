using Extreme_Moto_Store.DataAccess.Repository.iRepository;
using Extreme_Moto_Store.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Extreme_Moto_Store.Pages.Admin.Products
{
    public class IndexModel : PageModel
    {

        //For testing only

            //private readonly IUnitOfWork _unitOfWork;

            //public IEnumerable<Product> Products { get; set; }

            //public IndexModel(IUnitOfWork unitOfWork)
            //{
            //    _unitOfWork = unitOfWork;
            //}


            public void OnGet()
            {
                //Products = _unitOfWork.Product.GetAll();
            }
        }
    }
