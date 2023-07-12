namespace KriniteWebShop.WebUI.Blazor.Models;

public record CartModel(string UserName, IEnumerable<CartItemModel> Items, decimal TotalPrice);
