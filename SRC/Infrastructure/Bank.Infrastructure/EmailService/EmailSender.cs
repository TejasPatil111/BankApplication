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
                var fromEmail = _config["EmailSettings:From"]; // Use your email
                var password = _config["EmailSettings:Password"];      // Use an app-specific password (not real password)
                var host = _config["EmailSettings:SmtpHost"];
                var port = int.Parse(_config["EmailSettings:SmtpPort"]);

                using (var smtp = new SmtpClient(host))
                {
                    smtp.Port = port;
                    smtp.Credentials = new NetworkCredential(fromEmail, password);
                    smtp.EnableSsl = true;

                    var message = new MailMessage(fromEmail, toEmail, subject, body)
                    {
                        IsBodyHtml = true
                    };

                    try
                    {
                        await smtp.SendMailAsync(message);
                    }
                    catch (SmtpException ex)
                    {
                        Console.WriteLine($"SMTP Error: {ex.Message}");
                        throw; // or log it using ILogger
                    }
                }
            }
        }
    }
}
