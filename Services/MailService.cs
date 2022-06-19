using MailKit.Net.Smtp;
using MailkitApi.Models;
using MimeKit;

namespace MailkitApi.Services
{
    public class MailService : IMailService
    {
        private readonly IConfiguration _config;

        public MailService(IConfiguration config)
        {
            _config = config;
        }

        public void SendMail(MailDto request)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Josue Dare", "josue.dare99@ethereal.email"));
            message.To.Add(new MailboxAddress(request.To, request.ToMailAddress));
            message.Subject = request.Subject;

            message.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = request.Message
            };

            using var client = new SmtpClient();
            client.Connect(_config.GetSection("MailHost").Value, 587, MailKit.Security.SecureSocketOptions.StartTls);
            client.Authenticate(_config.GetSection("MailUsername").Value, _config.GetSection("MailPassword").Value);
            client.Send(message);
            client.Disconnect(true);
        }
    }
}