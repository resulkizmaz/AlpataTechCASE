using Business;
using Entity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IAuthenticationService authenticationService;
        UserController(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }

        [HttpPost]
        [Route("register-user")]
       public async Task<IActionResult> RegisterUser([FromForm] RegisterRequest registerRequest)
        {
                var result = await this.authenticationService.RegisterUser(registerRequest);
                if (result.Success)
                    return Ok(result);
                else
                    return BadRequest(result);
            
        }
    }
}
