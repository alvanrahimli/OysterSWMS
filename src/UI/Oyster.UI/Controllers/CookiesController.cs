using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Oyster.UI.Controllers;

[Route("Api/[controller]")]
public class CookiesController : ControllerBase
{
    private readonly IMemoryCache _memoryCache;
    private readonly ILogger<CookiesController> _logger;

    public CookiesController(IMemoryCache memoryCache, ILogger<CookiesController> logger)
    {
        _memoryCache = memoryCache;
        _logger = logger;
    }

    [HttpGet("Set-Auth")]
    public async Task<ActionResult> SetAuthCookie(string key)
    {
        if (string.IsNullOrEmpty(key))
        {
            return Redirect("/");
        }

        var principal = _memoryCache.Get<ClaimsPrincipal>(key);
        _memoryCache.Remove(key);
        if (principal?.Identity?.IsAuthenticated ?? false)
        {
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
            _logger.LogInformation("User {User} signed in", principal.Identity.Name);
            return Redirect("/");
        }

        return Redirect("/");
    }
    
    [HttpGet("Remove-Auth")]
    public async Task<ActionResult> RemoveAuthCookie()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return Redirect("/");
    }
}
