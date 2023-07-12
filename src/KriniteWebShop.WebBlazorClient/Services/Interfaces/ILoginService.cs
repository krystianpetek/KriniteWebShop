using KriniteWebShop.WebBlazorClient.Authorize.Models;

namespace KriniteWebShop.WebBlazorClient.Services.Interfaces;

public interface ILoginService
{
    Task Login(string userName);
}
