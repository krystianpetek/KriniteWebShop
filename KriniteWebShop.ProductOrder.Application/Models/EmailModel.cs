namespace KriniteWebShop.ProductOrder.Application.Models;
public class EmailModel
{
    public required string To { get; set; }
    public required string Subject { get; set; }
    public required string Body { get; set; }
}
