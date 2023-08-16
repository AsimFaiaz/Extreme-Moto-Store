﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extreme_Moto_Store.DataAccess.Repository.iRepository
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository Category { get; }
        IItemTypeRepository ItemType { get; }
        IProductRepository Product { get; }
        IShoppingCartRepository ShoppingCart { get; }
        IOrderDetailRepository OrderDetails { get; }
        IOrderHeaderRepository OrderHeader { get; }
        IApplicationUserRepository ApplicationUser { get; }
        void Save();
    }
}
