using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repository;
using ApplicationCore.Interfaces.Services;
using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class ProductServiceAsync : IProductServiceAsync
    {
        private readonly IProductRepositoryAsync productRepositoryAsync;
        private readonly IMapper mapper;
        public ProductServiceAsync(IProductRepositoryAsync repo, IMapper mapper)
        {
            productRepositoryAsync = repo;
            this.mapper = mapper;
        }

        public async Task<int> DeleteProductAsync(int id)
        {
            var result = await productRepositoryAsync.GetAsync(id);
            if(result == null)
            {
                return -1;
            }
            return await productRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<ProductResponseModel>> GetAllProductAsync()
        {
            var result = await productRepositoryAsync.GetAllAsync();
            return mapper.Map<IEnumerable<ProductResponseModel>>(result);
        }

        public async Task<ProductResponseModel> GetProductByIdAsync(int id)
        {
            var result = await productRepositoryAsync.GetAsync(id);
            return mapper.Map<ProductResponseModel>(result);
        }

        public async Task<int> InsertProductAsync(ProductRequestModel model)
        {
            //Product p = new Product();
            //p.Price = model.Price;
            //p.Discount = model.Discount;
            //p.Description = model.Description;
            //p.Name = model.Name;
            //return productRepositoryAsync.InsertAsync(p);


            return await productRepositoryAsync.InsertAsync(mapper.Map<Product>(model));
        }

        public async Task<int> UpdateProductAsync(ProductRequestModel model, int id)
        {
            var result = await productRepositoryAsync.GetAsync(id);
            if(result == null)
            {
                return -1;
            }
            return await productRepositoryAsync.UpdateAsync(mapper.Map<Product>(model));
        }
    }
}
