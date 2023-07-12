using KriniteWebShop.WebUI.Blazor.Authorize.Models;

namespace KriniteWebShop.WebUI.Blazor.Services.Interfaces;

public interface ILoginService
{
    Task Login(string userName);
}
