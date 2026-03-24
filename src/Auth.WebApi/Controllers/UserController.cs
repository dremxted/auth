using Microsoft.AspNetCore.Mvc;

namespace Auth.WebApi.Controllers;

[ApiController]
public class UserController : ControllerBase
{
    [HttpGet("api/current")]
    public IActionResult GetUser()
    {
        Dictionary<string,string> claims = new();
        
        foreach(var claim in HttpContext.User.Claims)
        {
            claims.Add(claim.Type, claim.Value);
        }

        return Ok(claims);
    }
}
