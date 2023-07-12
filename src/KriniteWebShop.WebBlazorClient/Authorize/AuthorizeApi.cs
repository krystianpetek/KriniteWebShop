using KriniteWebShop.WebBlazorClient.Authorize.Models;

namespace KriniteWebShop.WebBlazorClient.Authorize;

public class AuthorizeApi : IAuthorizeApi
{
    private readonly HttpClient _httpClient;
    public AuthorizeApi(HttpClient httpClient)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    }

    public Task<UserInfoModel> GetUserInfo()
    {
        throw new NotImplementedException();
    }

    public Task Login(LoginModel loginParameters)
    {
        throw new NotImplementedException();
    }

    public Task Logout()
    {
        throw new NotImplementedException();
    }

    public Task Register(RegisterModel registerParameters)
    {
        throw new NotImplementedException();
    }
}
