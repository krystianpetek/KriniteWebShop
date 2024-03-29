﻿namespace KriniteWebShop.Cart.API.Entities;

public class ShoppingCart
{
	public string UserName { get; set; }
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

	public ShoppingCart() { }

	public ShoppingCart(string userName)
	{
		UserName = userName;
	}
}
