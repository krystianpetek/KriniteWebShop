﻿using System.Text.Json.Serialization;

namespace KriniteWebShop.Coupon.API.Entities;

public class RestCoupon : ICoupon
{
	[JsonIgnore]
	public int Id { get; set; }
	public string ProductName { get; set; }
	public string Description { get; set; }
	public int Amount { get; set; }
}
