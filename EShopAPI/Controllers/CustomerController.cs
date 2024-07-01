using ApplicationCore.Interfaces.Services;
using ApplicationCore.Models.Request;
using Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.Common;

namespace EShopAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerServiceAsync customerServicesAsync;

        public CustomerController(ICustomerServiceAsync repo)
        {
            customerServicesAsync = repo;
        }
        [HttpPost]
        public async Task<IActionResult> Post(CustomerRequestModel customerRequestModel)
        {
            var result = await customerServicesAsync.InsertCustomerAsync(customerRequestModel);
            if (result > 0)
                return Ok();
            return BadRequest(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await customerServicesAsync.GetAllCustomerAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var customer = await customerServicesAsync.GetCustomerByIdAsync(id);
            if (customer == null)
            {
                return NotFound(new { Message = "We don't have that ID customer, please enter again" });
            }
            else
            {
                return Ok(customer);
            }

        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await customerServicesAsync.DeleteCustomerAsync(id);
            if (result == -1)
            {
                return NotFound(new {Message = "Cannot find that customer, cannot delete" });
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Put(CustomerRequestModel model, [FromQuery] int id)
        {
            return Ok(await customerServicesAsync.UpdateCustomerAsync(model, id));
        }










        //[HttpGet]
        //public IActionResult Get()
        //{

        //    return Ok("Customer get method is working fine");
        //}

        //[HttpGet]
        //[Route("{name}")]
        //public IActionResult Get(string name)
        //{

        //    return Ok($"Welcome to API {name}");
        //}

        //[HttpGet]
        //public IActionResult GetCity(string city)
        //{

        //    return Ok($"Welcome to city {city}");
        //}

        //[HttpGet]
        //[Route("{name}/{city}")]
        //public IActionResult Get(string name, string city)
        //{

        //    //return Ok($"Welcome to {name} and {city}");
        //    return Created();
        //}



        //[HttpPost]
        //public IActionResult Post([FromBody]String name, String city)
        //{
        //    return Ok($"{name} and {city}");
        //}


        ////[HttpPost]
        ////public IActionResult AddCustomer(Customer customer)
        ////{
        ////    return Ok(customer);
        ////}



        //[HttpDelete]
        //[Route("{id:int:max(500):min(1)}")]
        //public IActionResult Delete(int id) 
        //{
        //    return Ok($"Record with id {id} has been deleted");

        //}
    }
}
