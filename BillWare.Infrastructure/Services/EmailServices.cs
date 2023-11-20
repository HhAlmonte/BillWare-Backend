using BillWare.Application.Common.Models;
using BillWare.Application.Contracts.Service;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace BillWare.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;

        public EmailService(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public async Task<bool> SendEmailAsync(string to, 
                                               string subject, 
                                               string body)
        {
            try
            {
                using (var smtpClient = new SmtpClient(_emailSettings.SmtpServer))
                {
                    smtpClient.Port = _emailSettings.SmtpPort;
                    smtpClient.Credentials = new NetworkCredential(_emailSettings.SmtpUserName, _emailSettings.SmtpPassword);
                    smtpClient.EnableSsl = true;

                    var message = new MailMessage
                    {
                        From = new MailAddress(_emailSettings.SmtpUserName),
                        Subject = subject,
                        Body = body,
                        IsBodyHtml = false,
                    };

                    message.To.Add(to);

                    await smtpClient.SendMailAsync(message);

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al enviar el correo electrónico: {ex.Message}");
            }
        }

        public async Task<bool> SendEmailWithAttachmentsAsync(string to, 
                                                              string subject,
                                                              string body,
                                                              List<Attachment> attachments)
        {
            try
            {
                using (var smtpClient = new SmtpClient(_emailSettings.SmtpServer))
                {
                    smtpClient.Port = _emailSettings.SmtpPort;
                    smtpClient.Credentials = new NetworkCredential(_emailSettings.SmtpUserName, _emailSettings.SmtpPassword);
                    smtpClient.EnableSsl = true;

                    var message = new MailMessage
                    {
                        From = new MailAddress(_emailSettings.SmtpUserName),
                        Subject = subject,
                        Body = body,
                        IsBodyHtml = false,
                    };

                    message.To.Add(to);

                    foreach (var attachment in attachments)
                    {
                        message.Attachments.Add(attachment);
                    }

                    await smtpClient.SendMailAsync(message);

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al enviar el correo electrónico: {ex.Message}");
            }
        }

        public async Task<bool> SendHtmlEmailAsync(string to, 
                                                   string subject, 
                                                   string htmlBody)
        {
            try
            {
                using (var smtpClient = new SmtpClient(_emailSettings.SmtpServer))
                {
                    smtpClient.Port = _emailSettings.SmtpPort;
                    smtpClient.Credentials = new NetworkCredential(_emailSettings.SmtpUserName, _emailSettings.SmtpPassword);
                    smtpClient.EnableSsl = true;

                    var message = new MailMessage
                    {
                        From = new MailAddress(_emailSettings.SmtpUserName),
                        Subject = subject,
                        Body = htmlBody,
                        IsBodyHtml = true,
                    };

                    message.To.Add(to);

                    await smtpClient.SendMailAsync(message);

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al enviar el correo electrónico: {ex.Message}");
            }
        }
    }
}
