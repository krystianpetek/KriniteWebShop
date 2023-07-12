namespace KriniteWebShop.Order.Application.Models;
public class EmailSettings
{
	public required string SmtpHost { get; set; }
	public required int SmtpPort { get; set; }
	public required string SmtpEmail { get; set; }
	public required string SmtpSenderName { get; set; }
	public required UserSettings SmtpCredentials { get; set; }
}

public class UserSettings
{
	public required string SmtpPassword { get; set; }
	public required string SmtpUserName { get; set; }
}
