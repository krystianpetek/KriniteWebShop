using KriniteWebShop.WebUI.Blazor.Authorize.Models;
using KriniteWebShop.WebUI.Blazor.Services.Interfaces;
using Microsoft.AspNetCore.Components.Authorization;

namespace KriniteWebShop.WebUI.Blazor.Services;

public class LoginService : ILoginService
{
    private readonly AuthenticationStateProvider _authenticationStateProvider;

    public LoginService(AuthenticationStateProvider authenticationStateProvider)
    {
        _authenticationStateProvider = authenticationStateProvider;
    }

    public Task Login(string userName)
    {
        ((CustomAuthenticationStateProvider)_authenticationStateProvider).SetUserName(userName);
        return Task.CompletedTask;
    }
}
