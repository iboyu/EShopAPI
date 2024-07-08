using ApplicationCore.Interfaces.Services;
using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EShopAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationServiceAsync AuthenticationServiceAsync;

        public AuthenticationController(IAuthenticationServiceAsync repo)
        {
            AuthenticationServiceAsync = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAuthentication()
        {
            var result = await AuthenticationServiceAsync.GetAllAuthentication();
            if(result  == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAuthenticationById(int id)
        {
            var result = await AuthenticationServiceAsync.GetAuthenticationById(id);
            if(result == null)
            {
                return NotFound(new { Message = "Cannot find that Authentication by that Id, please enter again" });
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(AuthenticationRequestModel model)
        {
            return Ok(await AuthenticationServiceAsync.InsertAuthentication(model));
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await AuthenticationServiceAsync.GetAuthenticationById(id);
            if( result == null)
            {
                return NotFound(new { Message = "Cannot find that Authentication by that Id." });
            }
            return Ok(await AuthenticationServiceAsync.DeleteAuthentication(id));
        }

        [HttpPut]
        public async Task<IActionResult> Put(AuthenticationRequestModel model, [FromQuery] int id)
        {
            return Ok(await AuthenticationServiceAsync.UpdateAuthentication(model, id));

        }
    }
}
