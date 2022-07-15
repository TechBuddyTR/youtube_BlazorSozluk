using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace BlazorSozluk.WebApp.Infrastructure.Extensions;

public static class AuthenticationStateProviderExtension
{
    public static async Task<Guid> GetUserId(this AuthenticationStateProvider provider)
    {
        var state = await provider.GetAuthenticationStateAsync();
        var userId = state.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        return !string.IsNullOrEmpty(userId) ? new Guid(userId) : Guid.Empty;
    }
}
