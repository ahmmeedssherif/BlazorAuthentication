using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace BlazorApp1.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly string _fromEmail = "[Your Email at outlook]";
        private readonly string _fromPassword = "[Your Password at outlook]";
        private readonly string _smtpHost = "smtp-mail.outlook.com";
        private readonly int _smtpPort = 587;

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var message = new MailMessage();
            message.From = new MailAddress(_fromEmail);
            message.Subject = subject;
            message.To.Add(email);
            message.Body = $"<html><body><p>{htmlMessage}</p></body></html>";
            message.IsBodyHtml = true;

            using (var smtpClient = new SmtpClient(_smtpHost, _smtpPort) {Credentials = new NetworkCredential(_fromEmail, _fromPassword), EnableSsl = true }) 
            { 
                await smtpClient.SendMailAsync(message);
            }
        }
    }
}
