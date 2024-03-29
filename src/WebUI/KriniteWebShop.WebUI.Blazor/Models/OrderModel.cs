﻿namespace KriniteWebShop.WebUI.Blazor.Models;

public record OrderModel(Guid Id, decimal TotalPrice, string FirstName, string LastName, string EmailAddress, string AddressLine, string Country, string State, string ZipCode, int PaymentMethod)
{
    public string? CardName { get; set; }

    public string? CardNumber { get; set; }

    public string? Expiration { get; set; }

    public string? CVV { get; set; }
}