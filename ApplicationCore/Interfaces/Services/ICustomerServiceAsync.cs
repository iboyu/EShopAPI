using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.Services
{
    public interface ICustomerServiceAsync
    {
        
        public Task<int> InsertCustomerAsync(CustomerRequestModel customer);
        public Task<int> UpdateCustomerAsync(CustomerRequestModel model, int id);
        public Task<int> DeleteCustomerAsync(int id);
        public Task<CustomerResponseModel> GetCustomerByIdAsync(int id);
        public Task<IEnumerable<CustomerResponseModel>> GetAllCustomerAsync();

    }
}
