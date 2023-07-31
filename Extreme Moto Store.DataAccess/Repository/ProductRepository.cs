using Extreme_Moto_Store.DataAccess.Data;
using Extreme_Moto_Store.DataAccess.Repository.iRepository;
using Extreme_Moto_Store.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extreme_Moto_Store.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {

        private readonly ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Product product)
        {
            //Another way of updating using EFcore
            var objFromDb = _db.Product.FirstOrDefault(u=>u.Id == product.Id); //Retrieve category object from database
            objFromDb.Name = product.Name;
            objFromDb.Description = product.Description;
            objFromDb.Price = product.Price;
            objFromDb.CategoryId = product.CategoryId;
            objFromDb.ItemTypeId = product.ItemTypeId;

            //Image property
            if(objFromDb.Image != null) 
            {
                objFromDb.Image = product.Image;
            }

        }
    }
}
