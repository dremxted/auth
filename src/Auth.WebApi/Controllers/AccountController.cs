using Auth.WebApi.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Auth.WebApi.Controllers;

[ApiController]
[AllowAnonymous]
public class AccountController : ControllerBase
{
    [HttpPost("api/login")]
    public async Task LoginAsync(LoginRequestDto loginRequestDto)
    {
        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Name, loginRequestDto.Username),
        };

        var claimsIdentity = new ClaimsIdentity(
            claims: claims,
            authenticationType: CookieAuthenticationDefaults.AuthenticationScheme,
            nameType: ClaimTypes.Name,
            roleType: default);

        var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

        await HttpContext.SignInAsync(
            scheme: CookieAuthenticationDefaults.AuthenticationScheme,
            principal: claimsPrincipal);
    }

    [HttpPost("api/logout")]
    public async Task LogoutAsync()
    {
        await HttpContext.SignOutAsync(
            scheme: CookieAuthenticationDefaults.AuthenticationScheme);
    }
}