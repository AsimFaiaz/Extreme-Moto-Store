using Extreme_Moto_Store.DataAccess.Data;
using Extreme_Moto_Store.DataAccess.Repository.iRepository;
using Extreme_Moto_Store.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace Extreme_Moto_Store.Pages.Admin.ItemTypes
{
    [BindProperties]
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public IEnumerable <ItemType> ItemTypes { get; set; }

        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public void OnGet()
        {
            ItemTypes = _unitOfWork.ItemType.GetAll();
        }
    }
}
