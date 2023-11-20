using BillWare.Application.Contracts.Services;

namespace BillWare.Infrastructure.Services
{
    public class HtmlService : IHtmlService
    {
        public void GeneratePdfFromHtml(string htmlContent, string outputPath)
        {
            var htmlToPdf = new ChromePdfRenderer();

            var pdfDocumet = htmlToPdf.RenderHtmlAsPdf(htmlContent);

            var file = pdfDocumet.BinaryData;

            File.WriteAllBytes(outputPath, file);
        }
    }
}
