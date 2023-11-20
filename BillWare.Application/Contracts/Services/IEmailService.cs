using System.Net.Mail;

namespace BillWare.Application.Contracts.Service
{
    public interface IEmailService
    {
        Task<bool> SendEmailAsync(string to, string subject, string body);
        Task<bool> SendEmailWithAttachmentsAsync(string to, 
                                                 string subject,
                                                 string body, 
                                                 List<Attachment> attachments);
        Task<bool> SendHtmlEmailAsync(string to, string subject, string htmlBody);
    }
}
