using BillWare.Application.Common.Models;
using BillWare.Application.Interfaces;
using Microsoft.Extensions.Options;
using System.Net.Mail;
using System.Net;

namespace BillWare.Infrastructure.Services
{
    public class EmailServices : IEmailServices
    {
        private readonly EmailSettings _emailSettings;

        public EmailServices(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public async Task<bool> SendEmailAsync(string to, string subject, string body)
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

        public async Task<bool> SendEmailWithAttachmentsAsync(string to, string subject, string body, string pdfAttachments)
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

                    foreach (var pdfAttachmentBytes in pdfAttachments)
                    {
                        using (var ms = new MemoryStream(pdfAttachmentBytes))
                        {
                            message.Attachments.Add(new Attachment(ms, "archivo.pdf", "application/pdf"));
                        }
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

        public async Task<bool> SendHtmlEmailAsync(string to, string subject, string htmlBody)
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
