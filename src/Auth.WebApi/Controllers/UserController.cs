using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Auth.WebApi.Controllers;

[ApiController]
public class UserController : ControllerBase
{
    [HttpGet("api/current")]
    public IActionResult GetUser()
    {
        Dictionary<string, string> claims = new();

        foreach (var claim in HttpContext.User.Claims)
        {
            claims.Add(claim.Type, claim.Value);
        }

        return Ok(claims);
    }

    [HttpGet("api/accesstoken")]
    public async Task<IActionResult> GetAccessToken()
    {
        string? token = await HttpContext.GetTokenAsync("access_token");
        return Ok(token);
    }

    [HttpGet("api/idtoken")]
    public async Task<IActionResult> GetIdToken()
    {
        string? token = await HttpContext.GetTokenAsync("id_token");
        return Ok(token);
    }

}