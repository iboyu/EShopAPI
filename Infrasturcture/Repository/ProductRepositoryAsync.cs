using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repository;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class ProductRepositoryAsync:BaseRepositoryAsync<Product>,IProductRepositoryAsync
    {
        public ProductRepositoryAsync(EShopDbContext db):base(db)
        {
            
        }
    }
}
