﻿using Extreme_Moto_Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extreme_Moto_Store.DataAccess.Repository.iRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        void Update(Product product);

    }
}