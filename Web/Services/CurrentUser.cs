using System.Security.Claims;
using Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Web.Services;

public class CurrentUser : IUser
{
    private readonly IHttpContextAccessor _httpContextAccesor;

    public CurrentUser(IHttpContextAccessor httpContextAccesor)
    {
        _httpContextAccesor = httpContextAccesor;
    }

    public string? Id => _httpContextAccesor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
}
