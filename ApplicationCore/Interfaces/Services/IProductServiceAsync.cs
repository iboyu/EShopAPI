using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.Services
{
    public interface IProductServiceAsync
    {
        public Task<int> InsertProductAsync(ProductRequestModel model);
        public Task<int> UpdateProductAsync(ProductRequestModel model, int id);
        public Task<int> DeleteProductAsync(int id);
        public Task<ProductResponseModel> GetProductByIdAsync(int id);
        public Task<IEnumerable<ProductResponseModel>> GetAllProductAsync();
        
    }
}
