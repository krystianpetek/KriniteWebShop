using System.ComponentModel.DataAnnotations;

namespace KriniteWebShop.WebBlazorClient.Authorize.Models;

public class RegisterModel
{
    [Required]
    public string UserName { get; set; }

    [Required]
    public string Password { get; set; }

    [Required]
    [Compare(nameof(Password), ErrorMessage = "Passwords do not match")]
    public string PasswordConfirm { get; set; }
}
