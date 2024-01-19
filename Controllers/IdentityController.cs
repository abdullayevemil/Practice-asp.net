using Microsoft.AspNetCore.Mvc;
using Turbo.az.Dtos;

namespace Turbo.az.Controllers
{
    public class IdentityController : Controller
    {
        [HttpGet]
        public IActionResult Login() => base.View();

        [HttpPost]
        public IActionResult Login([FromForm]UserDto userDto)
        {
            
            return Ok();
        }
    }
}