using ApplicationCore.Entities;
using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;
using AutoMapper;
namespace EShopAPI
{
    public class ApplicationMapper:Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Product, ProductRequestModel>().ReverseMap();
            CreateMap<ProductResponseModel, Product>().ReverseMap();
            CreateMap<Customer, CustomerRequestModel>().ReverseMap();
            CreateMap<Customer,CustomerResponseModel>().ReverseMap();
            CreateMap<Authentication, AuthenticationRequestModel>().ReverseMap();
            CreateMap<Authentication, AuthenticationResponseModel>().ReverseMap();
        }
    }
}
