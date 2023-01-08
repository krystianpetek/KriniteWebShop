using KriniteWebShop.ProductOrder.Application.Contracts.Infrastructure;
using KriniteWebShop.ProductOrder.Application.Models;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;

namespace KriniteWebShop.ProductOrder.Infrastructure.Email;
public class EmailService : IEmailService
{
    private readonly EmailSettings _emailSettings;
    private readonly ILogger<EmailService> _logger;

    public EmailService(IOptions<EmailSettings> emailSettings, ILogger<EmailService> logger)
    {
        _emailSettings = emailSettings.Value ?? throw new ArgumentNullException(nameof(emailSettings));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<bool> SendMail(EmailModel email)
    {
        var client = new SmtpClient();
        MimeMessage mimeMessage = new MimeMessage();
        mimeMessage.From.Add(new MailboxAddress(_emailSettings.SmtpSenderName, _emailSettings.SmtpEmail));
        mimeMessage.To.Add(new MailboxAddress("TO", email.To));
        mimeMessage.Subject = email.Subject;

        await client.ConnectAsync(_emailSettings.SmtpHost, _emailSettings.SmtpPort, SecureSocketOptions.StartTls);
        await client.AuthenticateAsync(_emailSettings.SmtpCredentials.SmtpUserName, _emailSettings.SmtpCredentials.SmtpPassword);

        await client.SendAsync(mimeMessage);
        await client.DisconnectAsync(true);
        return true;
    }
}
