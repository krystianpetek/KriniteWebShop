namespace KriniteWebShop.PurchaseAggregator.Models;

public class PurchaseModel
{
    public string? UserName { get; set; }
    public CartModel? Cart { get; set; }
    public IEnumerable<OrderModel>? Orders { get; set; }
}
