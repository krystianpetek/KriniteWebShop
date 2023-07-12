using KriniteWebShop.WebUI.Blazor.Authorize.Models;

namespace KriniteWebShop.WebUI.Blazor.Authorize;

public interface IAuthorizeApi
{
    Task Login(LoginModel loginParameters);
    Task Register(RegisterModel registerParameters);
    Task Logout();
    Task<UserInfoModel> GetUserInfo();
}
