﻿namespace Old_KriniteWebShop.WebUI.RazorPages.Models;

public class CartItemModel
{
    public string? ProductId { get; set; }

    public string? ProductName { get; set; }

    public int? Quantity { get; set; }

    public decimal? Price { get; set; }
}