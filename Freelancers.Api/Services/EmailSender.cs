using Freelancers.Api.Settings;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;

namespace Freelancers.Api.Services;

public class EmailSender(IOptions<MailSettings> mailSettings) : IEmailSender
{

	private readonly MailSettings _mailSettings = mailSettings.Value;

	public async Task SendEmailAsync(string email, string subject, string htmlMessage)
	{
		var message = new MimeMessage
		{
			Sender = MailboxAddress.Parse(_mailSettings.Email),
			Subject = subject,
		};
		message.To.Add(MailboxAddress.Parse(email));

		var builder = new BodyBuilder
		{
			HtmlBody = htmlMessage,
		};

		message.Body = builder.ToMessageBody();

		using var smtp = new SmtpClient();


		smtp.Connect(_mailSettings.Host, _mailSettings.port, SecureSocketOptions.StartTls);
		smtp.Authenticate(_mailSettings.Email, _mailSettings.Password);
		await smtp.SendAsync(message);
		smtp.Disconnect(true);
	}
}
