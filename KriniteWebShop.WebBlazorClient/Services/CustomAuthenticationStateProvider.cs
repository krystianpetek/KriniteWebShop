﻿using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace KriniteWebShop.WebBlazorClient.Services;

public class CustomAuthenticationStateProvider : AuthenticationStateProvider
{
    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var identity = new ClaimsIdentity(new[]
        {
            new Claim(ClaimTypes.Name, "krystianpetek")
        }, "Custom Authentication");

        var user = new ClaimsPrincipal(identity);
        return Task.FromResult(new AuthenticationState(user));
    }
}
