using System.ComponentModel.DataAnnotations;

namespace KriniteWebShop.WebUI.Blazor.Authorize.Models;

public record LoginModel([Required] string UserName, [Required] string Password, bool RememberMe);

