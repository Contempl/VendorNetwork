using Product.Services.Implementations;
using System.Net.Mail;

namespace Product.Services.Interfaces;

public interface IEmailService
{
	Task SendInvitationEmailAsync(MailMsg mailMessage);
	MailMsg CreateMessage(string emailBody, string senderEmail);
}
