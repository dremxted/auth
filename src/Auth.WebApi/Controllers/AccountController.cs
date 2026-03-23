using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Auth.WebApi.Controllers;

[ApiController]
[AllowAnonymous]
public class AccountController : ControllerBase
{
    [HttpGet("api/login/google")]
    public IActionResult Login(string returnUrl)
    {
        if(!Url.IsLocalUrl(returnUrl))
        {
            return BadRequest();
        }

        AuthenticationProperties authenticationProperties = new()
        {
            RedirectUri = returnUrl
        };

        return Challenge(
            authenticationProperties, 
            GoogleDefaults.AuthenticationScheme);
    }
}
