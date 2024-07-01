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
    public class CustomerServicesAsync : ICustomerServiceAsync
    {
        private readonly ICustomerRepositoryAsync customerRepository;
        private readonly IMapper mapper;

        public CustomerServicesAsync(ICustomerRepositoryAsync repo, IMapper mapper)
        {
            customerRepository = repo;
            this.mapper = mapper;
        }

        public async Task<int> DeleteCustomerAsync(int id)
        {
            var result = await customerRepository.GetAsync(id);
            if(result == null)
            {
                return -1;
            }
            return await customerRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<CustomerResponseModel>> GetAllCustomerAsync()
        {
            var customers = await customerRepository.GetAllAsync();

            var CustomerResponseModel = mapper.Map<IEnumerable<CustomerResponseModel>>(customers);
            return CustomerResponseModel;
            //var CustomerResponseModel = new List<CustomerResponseModel>();
            //foreach (var customer in customers) {
            //    var model = new CustomerResponseModel()
            //    {
            //        FirstName = customer.FirstName,
            //        LastName = customer.LastName,
            //        Gender = customer.Gender,
            //        Phone = customer.Phone
            //    };
            //    CustomerResponseModel.Add(model);
            //}
            //return CustomerResponseModel;

        }

        public async Task<CustomerResponseModel> GetCustomerByIdAsync(int id)
        {

            var itemById = await customerRepository.GetAsync(id);
            if (itemById != null)
            {
                var model = mapper.Map<CustomerResponseModel>(itemById);
                return model;
            }
            return null;
            //var item = await customerRepository.GetAsync(id);
            //if(item != null)
            //{
            //    CustomerRequestModel model = new CustomerRequestModel();
            //    model.Gender = item.Gender;
            //    model.FirstName = item.FirstName;
            //    model.LastName = item.LastName;
            //    model.Phone = item.Phone;
            //    return model;
            //}
            //return null;
        }

        public async Task<int> InsertCustomerAsync(CustomerRequestModel customer)
        {
            //Customer c = new Customer();
            //c.FirstName = customer.FirstName;
            //c.LastName = customer.LastName;
            //c.Gender = customer.Gender;
            //c.Phone = customer.Phone;


            //return await customerRepository.InsertAsync(c);

            return await customerRepository.InsertAsync(mapper.Map<Customer>(customer));
        }

        public async Task<int> UpdateCustomerAsync(CustomerRequestModel model, int id)
        {
            var findCustomer = await customerRepository.GetAsync(id);
            if (findCustomer == null)
            {
                return -1;
            }
            //if (findCustomer != null)
            //{
            //    findCustomer.FirstName = model.FirstName;
            //    findCustomer.LastName = model.LastName;
            //    findCustomer.Gender = model.Gender;
            //    findCustomer.Phone = model.Phone;

            //    return await customerRepository.UpdateAsync(findCustomer);
            return await customerRepository.UpdateAsync(mapper.Map<Customer>(findCustomer));
        }
        //else
        //{
        //    return 0;
        //}

        //Customer c = new Customer();
        //c.Gender = model.Gender;
        //c.Phone = model.Phone;
        //c.FirstName = model.FirstName;
        //c.LastName = model.LastName;
        //c.Id = id;
        //return customerRepository.UpdateAsync(c);
    }
}

