using KriniteWebShop.ProductOrder.Domain.Common;

namespace KriniteWebShop.ProductOrder.Domain.Entities;
public class Order : EntityBase
{
    public required string UserName { get; set; }
    public required decimal TotalPrice { get; set; }

    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string EmailAddress { get; set; }
    public required string AddressLine { get; set; }
    public required string Country { get; set; }
    public required string State { get; set; }
    public required string ZipCode { get; set; }

    public required string CardName { get; set; }
    public required string CardNumber { get; set; }
    public required string Expiration { get; set; }
    public required string CVV { get; set; }
    public required int PaymentMethod { get; set; }
}
