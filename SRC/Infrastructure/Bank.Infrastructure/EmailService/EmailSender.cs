using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Bank.Application.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Bank.Infrastructure.EmailService
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _config;

        public EmailSender(IConfiguration config)
        {
            _config = config;
        }
        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {

            {
                var fromEmail = "rp1767407@gmail.com"; // Use your email
                var password = "ogrlijlldntvpzld";      // Use an app-specific password (not real password)

                using (var smtp = new SmtpClient("smtp.gmail.com"))
                {
                    smtp.Port = 587;
                    smtp.Credentials = new NetworkCredential(fromEmail, password);
                    smtp.EnableSsl = true;

                    var message = new MailMessage(fromEmail, toEmail, subject, body)
                    {
                        IsBodyHtml = true
                    };

                    await smtp.SendMailAsync(message);
                }
            }
        }
    }
}
