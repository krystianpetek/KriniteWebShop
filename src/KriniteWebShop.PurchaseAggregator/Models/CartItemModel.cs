namespace KriniteWebShop.PurchaseAggregator.Models;

public class CartItemModel
{
    public string? ProductId { get; set; }

    public string? ProductName { get; set; }

    public int? Quantity { get; set; }

    public decimal? Price { get; set; }

    public string? Category { get; set; }

    public string? Description { get; set; }
}