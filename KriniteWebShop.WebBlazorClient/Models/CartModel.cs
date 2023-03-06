namespace KriniteWebShop.WebBlazorClient.Models;

public record CartModel (string UserName, IEnumerable<CartItemModel> Items, decimal TotalPrice);
