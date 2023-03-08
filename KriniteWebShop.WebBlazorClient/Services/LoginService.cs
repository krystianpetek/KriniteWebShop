using KriniteWebShop.WebBlazorClient.Authorize.Models;
using KriniteWebShop.WebBlazorClient.Services.Interfaces;
using Microsoft.AspNetCore.Components.Authorization;

namespace KriniteWebShop.WebBlazorClient.Services;

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
