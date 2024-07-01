using ApplicationCore.Interfaces.Services;
using ApplicationCore.Models.Request;
using Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace EShopAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServiceAsync productServiceAsync;

        public ProductController(IProductServiceAsync repo)
        {
            productServiceAsync = repo;
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProductRequestModel model)
        {
            return Ok(await productServiceAsync.InsertProductAsync(model));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await productServiceAsync.GetAllProductAsync()); 
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await productServiceAsync.GetProductByIdAsync(id);
            if(result == null)
            {
                NotFound(new {Message = $"No product with ID: {id} found"});
            }
            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            var result = await productServiceAsync.DeleteProductAsync(id);
            if(result == -1)
            {
                return NotFound(new {Message = "Cannot find that product, cannot delete" });
            }
            return Ok(result);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(ProductRequestModel model, int id)
        {
            var result = await productServiceAsync.UpdateProductAsync(model, id);
            if (result == -1)
            {
                return NotFound(new {Message = "Cannot find product. Cannot update."});
            }
            return Ok(result);
        }
    }
}
