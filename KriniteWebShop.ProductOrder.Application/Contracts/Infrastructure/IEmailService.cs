using KriniteWebShop.ProductOrder.Application.Models;

namespace KriniteWebShop.ProductOrder.Application.Contracts.Infrastructure;
public interface IEmailService
{
    Task<bool> SendMail(Email email);
}
