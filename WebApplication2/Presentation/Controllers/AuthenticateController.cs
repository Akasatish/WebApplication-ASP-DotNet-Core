using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Domain.Interfaces;
using WebApplication2.Infrastructure;

namespace WebApplication2.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private ITokenManager tokenManager;

        public AuthenticateController(ITokenManager tokenManager)
        {
            this.tokenManager = tokenManager;
        }

        [HttpGet]
        public IActionResult Authenticate(string username, string password)
        {
            if (tokenManager.Authenticate(username, password))

                return Ok(tokenManager.NewToken());
            else
            {
                ModelState.AddModelError("unauthorised", "you are not authorized");
                return BadRequest();
            }


        }
    }
}

