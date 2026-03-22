using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Auth.WebApi.Controllers;

[ApiController]
public class UserController : ControllerBase
{
    [HttpGet("api/current")]
    public async Task<IActionResult> GetUser()
    {
        var name = HttpContext.User
            .FindFirst(ClaimTypes.Name);

        return name != null
            ? Ok($"Hello, {name.Value}!")
            : Unauthorized();
    }
}
