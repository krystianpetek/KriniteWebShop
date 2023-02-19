namespace KriniteWebShop.WebBlazorClient.Models;

public record CartModel (string UserName, IReadOnlyCollection<CartItemModel> Items, decimal TotalPrice);
