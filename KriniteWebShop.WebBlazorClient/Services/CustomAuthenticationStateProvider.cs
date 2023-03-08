using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace KriniteWebShop.WebBlazorClient.Services;

public class CustomAuthenticationStateProvider : AuthenticationStateProvider
{
    private string? UserName { get; set; }
    public void SetUserName(string userName)
    {
        UserName = userName;
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }

    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        ClaimsIdentity identity;
        if (UserName is null)
        {
            identity = new ClaimsIdentity();
        }
        else
        {
            identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, UserName)
            }, "Custom authentication");
        }

        var user = new ClaimsPrincipal(identity);
        return Task.FromResult(new AuthenticationState(user));
    }
}
