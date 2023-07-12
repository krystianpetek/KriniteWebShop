namespace KriniteWebShop.WebUI.Blazor.Models;

public record CartItemModel(string ProductId, string ProductName, int Quantity, decimal Price);