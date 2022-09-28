using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using System.Net;

namespace Core.Utilities.Helpers.EmailHelper
{
    public class EmailSenderManager : IEmailSenderService
    {
        SmtpSettings _smtpSettings;

        public EmailSenderManager(IOptions<SmtpSettings> smtpSettings)
        {
            _smtpSettings = smtpSettings.Value;
        }

        public void SendEmail(string recipientEmail,string message,string subject)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse( _smtpSettings.SenderEmail));
            email.To.Add(MailboxAddress.Parse(recipientEmail));
            email.Subject = subject;
            email.Body = new TextPart("plain")
            {
                Text = message
            };
            var client = new SmtpClient();
            client.Connect(_smtpSettings.Server, _smtpSettings.Port, true);
            client.Authenticate(new NetworkCredential(_smtpSettings.SenderEmail,_smtpSettings.Password));
            client.Send(email);
            client.Disconnect(true);
        }
    }
}
