using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Oyster.Domain.Data;
using Oyster.Domain.Models;
using Oyster.UI.Models;
using Oyster.Utils;

namespace Oyster.UI.Services;

public class AuthService
{
    private readonly ILogger<AuthService> _logger;
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly DataContext _context;

    public AuthService(ILogger<AuthService> logger, IHttpContextAccessor contextAccessor, DataContext context)
    {
        _logger = logger;
        _contextAccessor = contextAccessor;
        _context = context;
    }

    public async Task<(bool succeeded, string? error)> RegisterUser(RegisterMessage message)
    {
        var sameUsernameUser = await _context.Users.Where(x => x.Email == message.Email).ToListAsync();
        if (sameUsernameUser.Any())
        {
            _logger.LogWarning("Duplicate username found");
            return (false, "User associated with provided email already exists");
        }
        
        var user = new AppUser
        {
            FullName = message.FullName,
            Email = message.Email,
            PasswordHash = Crypto.GeneratePwdHash(message.Password)
        };

        await _context.Users.AddAsync(user);
        if (await _context.SaveChangesAsync() == 0)
        {
            return (false, "Could not add user");
        }
        
        _logger.LogInformation("Created new user {@User}", user);
        return (true, null);
    }

    public async Task<bool> LogInUser(LoginMessage message)
    {
        var possibleUsers = await _context.Users.Where(x => x.Email == message.Email).ToListAsync();
        var pwdHash = Crypto.GeneratePwdHash(message.Password);
        var user = possibleUsers.FirstOrDefault(u => u.PasswordHash == pwdHash);

        if (user is null)
        {
            _logger.LogWarning("User with username: {Username} not found", message.Email);
            return false;
        }

        var claimsIdentity = new ClaimsIdentity(new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Name, user.FullName)
        }, CookieAuthenticationDefaults.AuthenticationScheme);

        await _contextAccessor.HttpContext!.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentity));
        return true;
    }
    
    public async Task<ClaimsPrincipal?> GetUserClaimsPrincipal(LoginMessage message)
    {
        var possibleUsers = await _context.Users.Where(x => x.Email == message.Email).ToListAsync();
        var pwdHash = Crypto.GeneratePwdHash(message.Password);
        var user = possibleUsers.FirstOrDefault(u => u.PasswordHash == pwdHash);

        if (user is null)
        {
            _logger.LogWarning("User with username: {Username} not found", message.Email);
            return null;
        }

        var claimsIdentity = new ClaimsIdentity(new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Name, user.FullName)
        }, CookieAuthenticationDefaults.AuthenticationScheme);

        return new ClaimsPrincipal(claimsIdentity);
    }
}
