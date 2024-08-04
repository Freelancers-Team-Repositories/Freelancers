using Freelancers.Api.Settings;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace Freelancers.Api.Services;

public class EmailSender(IOptions<MailSettings> mailSettings) : IEmailSender
{

	private readonly MailSettings _mailSettings = mailSettings.Value;

	public async Task SendEmailAsync(string email, string subject, string htmlMessage)
	{
		MailMessage message = new()
		{
			From = new MailAddress(_mailSettings.Email, _mailSettings.DisplayName),
			Body = htmlMessage,
			IsBodyHtml = true,
			Subject = subject,
		};

		message.To.Add(email);

		SmtpClient smtpClient = new(_mailSettings.Host, _mailSettings.port)
		{
			Credentials = new NetworkCredential(_mailSettings.Email, _mailSettings.Password),
			EnableSsl = true,
		};

		await smtpClient.SendMailAsync(message);

		smtpClient.Dispose();
	}
}
