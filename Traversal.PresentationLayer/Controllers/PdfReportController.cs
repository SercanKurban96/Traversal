using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.PresentationLayer.Controllers
{
    public class PdfReportController : Controller
    {
        // Pdf oluşturmak için Presentation katmanından iTextSharp.LGPLv2.Core paketi kurulmalıdır.
        public IActionResult Index()
        {
            return View();
        }

        // pdf raporlarını tutmak için wwwroot dosyasına 1 tane klasör ekliyoruz. pdfreports adını veriyoruz.
        public IActionResult StaticPdfReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pdfreports/" + "dosya1.pdf");
            var stream = new FileStream(path, FileMode.Create);

            Document document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document, stream);

            document.Open();

            Paragraph paragraph = new Paragraph("Traversal Rezervasyon Pdf Raporu");

            document.Add(paragraph);
            document.Close();
            return File("/pdfreports/dosya1.pdf", "application/pdf", "dosya1.pdf");
        }

        public IActionResult StaticCustomerReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pdfreports/" + "dosya2.pdf");
            var stream = new FileStream(path, FileMode.Create);

            Document document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document, stream);

            document.Open();

            PdfPTable pdfPTable = new PdfPTable(3);

            pdfPTable.AddCell("Misafir Adı");
            pdfPTable.AddCell("Misafir Soyadı");
            pdfPTable.AddCell("Misafir TC");

            pdfPTable.AddCell("Ahmet");
            pdfPTable.AddCell("Karaca");
            pdfPTable.AddCell("11111111110");

            pdfPTable.AddCell("Yusuf");
            pdfPTable.AddCell("Kandemir");
            pdfPTable.AddCell("11111111112");

            pdfPTable.AddCell("Yeliz");
            pdfPTable.AddCell("Asya");
            pdfPTable.AddCell("11111111114");

            document.Add(pdfPTable);

            document.Close();
            return File("/pdfreports/dosya2.pdf", "application/pdf", "dosya2.pdf");
        }
    }
}
