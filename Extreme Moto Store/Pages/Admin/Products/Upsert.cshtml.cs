using Extreme_Moto_Store.DataAccess.Data;
using Extreme_Moto_Store.DataAccess.Repository.iRepository;
using Extreme_Moto_Store.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Extreme_Moto_Store.Pages.Admin.Products
{
    [BindProperties]   //Important, Null exp will be given if missing
    public class UpsertModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public Product Product { get; set; }

        //Getting items as a drop down menu from these two tables
        public IEnumerable<SelectListItem> CategoryList { get; set; }
        public IEnumerable<SelectListItem> ItemTypeList { get; set; }

        public UpsertModel(IUnitOfWork unitOfWork, IWebHostEnvironment hostingEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostingEnvironment = hostingEnvironment;

            Product = new();
        }

        public void OnGet()
        {
            CategoryList = _unitOfWork.Category.GetAll().Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString(),
            });

            ItemTypeList = _unitOfWork.ItemType.GetAll().Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString(),
            });
        }
        public async Task<IActionResult> OnPost()
        {
            string webRootPath = _hostingEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;

            if (Product.Id == 0)
            {
                //Create Image

                string fileName_new =Guid.NewGuid().ToString();
                var uploads = Path.Combine(webRootPath, @"images\products");
                var extension = Path.GetExtension(files[0].FileName);

                using (var fileStream = new FileStream(Path.Combine(uploads, fileName_new + extension),FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }

                Product.Image = @"\images\products\" + fileName_new + extension;
                _unitOfWork.Product.Add(Product);
                _unitOfWork.Save();
            }
            else
            {
                
            }
            return RedirectToPage("./Index");
        }
    }

}




