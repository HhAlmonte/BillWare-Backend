namespace BillWare.Application.Interfaces
{
    public interface IEmailServices
    {
        Task<bool> SendEmailAsync(string to, string subject, string body);
        Task<bool> SendEmailWithAttachmentsAsync(string to, string subject, string body, string pdfAttachments);
        Task<bool> SendHtmlEmailAsync(string to, string subject, string htmlBody);
    }
}
