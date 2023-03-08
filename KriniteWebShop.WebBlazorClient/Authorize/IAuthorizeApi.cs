using KriniteWebShop.WebBlazorClient.Authorize.Models;

namespace KriniteWebShop.WebBlazorClient.Authorize;

public interface IAuthorizeApi
{
    Task Login(LoginModel loginParameters);
    Task Register(RegisterModel registerParameters);
    Task Logout();
    Task<UserInfoModel> GetUserInfo();
}
