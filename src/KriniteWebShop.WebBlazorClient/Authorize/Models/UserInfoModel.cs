namespace KriniteWebShop.WebBlazorClient.Authorize.Models;

public class UserInfoModel
{
    public bool IsAuthenticated { get; set; }
    public string UserName { get; set; }
    public Dictionary<string, string> Claims { get; set; }
}
