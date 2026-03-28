using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Auth.WebApi.Controllers;

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
            OpenIdConnectDefaults.AuthenticationScheme);
    }
}
