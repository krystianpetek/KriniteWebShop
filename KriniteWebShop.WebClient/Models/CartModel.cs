namespace KriniteWebShop.WebClient.Models;

public class CartModel
{
    public string UserName { get; set; }

    public ICollection<CartItemModel>? Items { get; set; } = new List<CartItemModel>();

    public decimal? TotalPrice { get; set; }

}
