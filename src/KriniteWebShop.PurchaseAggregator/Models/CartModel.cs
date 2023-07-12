namespace KriniteWebShop.PurchaseAggregator.Models;

public class CartModel
{
    public ICollection<CartItemModel>? Items { get; set; } = new List<CartItemModel>();

    public decimal? TotalPrice { get; set; }

}
