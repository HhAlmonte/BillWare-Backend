namespace BillWare.Application.Contracts.Services
{
    public interface IHtmlService
    {
        void GeneratePdfFromHtml(string htmlContent, string outputPath);
    }
}
