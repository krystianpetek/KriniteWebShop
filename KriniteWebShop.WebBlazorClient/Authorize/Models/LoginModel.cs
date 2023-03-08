using System.ComponentModel.DataAnnotations;

namespace KriniteWebShop.WebBlazorClient.Authorize.Models;

public record LoginModel ([Required] string UserName, [Required] string Password, bool RememberMe);

