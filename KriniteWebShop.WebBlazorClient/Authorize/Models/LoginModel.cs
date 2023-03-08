using System.ComponentModel.DataAnnotations;

namespace KriniteWebShop.WebBlazorClient.Authorize.Models;

public class LoginModel
{
    [Required]
    public string UserName { get; set; }

    [Required]
    public string Password { get; set; }

    public bool RememberMe { get; set; }
}

