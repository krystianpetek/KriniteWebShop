﻿using KriniteWebShop.Order.Domain.Common;

namespace KriniteWebShop.Order.Domain.Entities;
public class OrderEntity : EntityBase
{
	public OrderEntity(Guid Id = default) { base.Id = Id; }

	public string? UserName { get; set; }
	public decimal? TotalPrice { get; set; }

	public string? FirstName { get; set; }
	public string? LastName { get; set; }
	public string? EmailAddress { get; set; }
	public string? AddressLine { get; set; }
	public string? Country { get; set; }
	public string? State { get; set; }
	public string? ZipCode { get; set; }

	public string? CardName { get; set; }
	public string? CardNumber { get; set; }
	public string? Expiration { get; set; }
	public string? CVV { get; set; }
	public PaymentMethod? PaymentMethod { get; set; }
}
public enum PaymentMethod
{
	Cash,
	Checks,
	DebitCards,
	CreditCards,
	MobilePayments,
	ElectronicBankTransfers
}
