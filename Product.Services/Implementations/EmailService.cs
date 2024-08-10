using Product.Services.Interfaces;

namespace Product.Services.Implementations;

public class EmailService : IEmailService
{
	public Task SendInvitationEmailAsync(MailMsg mailMessage)
	{
		return Task.CompletedTask;
	}

	public MailMsg CreateMessage(string emailBody, string senderEmail)
	{
		return new MailMsg(emailBody, senderEmail);
	}
}

public record MailMsg(string body, string sender);