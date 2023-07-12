using KriniteWebShop.Order.Application.Models;

namespace KriniteWebShop.Order.Application.Contracts.Infrastructure;
public interface IEmailService
{
	Task<bool> SendMail(EmailModel email);
}
