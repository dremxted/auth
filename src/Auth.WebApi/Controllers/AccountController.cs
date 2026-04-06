namespace Auth.WebApi.Controllers;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[AllowAnonymous]
public class AccountController : ControllerBase
{
    [HttpGet("api/login")]
    public IActionResult LoginOpenIddict(string returnUrl)
    {
        if (!Url.IsLocalUrl(returnUrl))
        {
            return BadRequest();
        }

        AuthenticationProperties authenticationProperties = new()
        {
            RedirectUri = returnUrl
        };

        return Challenge(
            authenticationProperties,
            "EntraId");
    }
}