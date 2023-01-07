using KriniteWebShop.ProductOrder.Application.Models;

namespace KriniteWebShop.ProductOrder.Application.Contracts.Infrastructure;
internal interface IEmailService
{
    Task<bool> SendMail(Email email);
}
