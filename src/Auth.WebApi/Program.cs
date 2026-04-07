using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
var entraConfig = config.GetSection("EntraId");

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = "EntraId";
})
    .AddCookie()
    .AddOpenIdConnect(
    authenticationScheme: "EntraId",
    configureOptions: options =>
    {
        options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        options.ResponseType = OpenIdConnectResponseType.Code;
        options.MapInboundClaims = false;
        options.UsePkce = true;

        options.CallbackPath = "/signin-entra";
        options.Authority = entraConfig["Authority"];
        options.ClientId = entraConfig["ClientId"];
        options.ClientSecret = entraConfig["ClientSecret"];

        options.Scope.Clear();
        options.Scope.Add("openid");
        options.Scope.Add("profile");
        options.Scope.Add("email");
    });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers()
    .RequireAuthorization();

app.Run();
