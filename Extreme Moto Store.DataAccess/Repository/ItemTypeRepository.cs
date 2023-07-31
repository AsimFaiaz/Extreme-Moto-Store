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
    public class ItemTypeRepository : Repository<ItemType>, IItemTypeRepository
    {

        private readonly ApplicationDbContext _db;

        public ItemTypeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(ItemType itemType)
        {
            //Another way of updating using EFcore
            var objFromDb = _db.ItemType.FirstOrDefault(u=>u.Id == itemType.Id); //Retrieve category object from database
            objFromDb.Name = itemType.Name;
        }
    }
}
