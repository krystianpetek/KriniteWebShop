namespace KriniteWebShop.Cart.API.Entities;

public class RestShoppingCart
{
	public ICollection<ShoppingCartItem> Items { get; set; } = new List<ShoppingCartItem>();
	public decimal TotalPrice
	{
		get
		{
			decimal totalPrice = 0;
			foreach (ShoppingCartItem item in Items)
			{
				totalPrice += item.Price * item.Quantity;
			}
			return totalPrice;
		}
	}
}
