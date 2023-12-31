﻿using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using Traversal.BusinessLayer.Abstract;
using Traversal.DataAccessLayer.Concrete;
using Traversal.PresentationLayer.Models;

namespace Traversal.PresentationLayer.Controllers
{
    public class ExcelController : Controller
    {
        // Excel oluşturmak için Presentation katmanından EPPlus paketi kurulmalıdır.

        private readonly IExcelServiceBL _excelServiceBL;

        public ExcelController(IExcelServiceBL excelServiceBL)
        {
            _excelServiceBL = excelServiceBL;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult StaticExcelReport()
        {
            return File(_excelServiceBL.ExcelList(DestinationList()), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "YeniExcel.xlsx");

            // Statik olarak kaydetme
            //ExcelPackage excel = new ExcelPackage();
            //var workSheet = excel.Workbook.Worksheets.Add("Sayfa1");
            //workSheet.Cells[1, 1].Value = "Rota";
            //workSheet.Cells[1, 2].Value = "Rehber";
            //workSheet.Cells[1, 3].Value = "Kontenjan";

            //workSheet.Cells[2, 1].Value = "Gürcistan Batum Turu";
            //workSheet.Cells[2, 2].Value = "Kadir Yıldız";
            //workSheet.Cells[2, 3].Value = "50";

            //workSheet.Cells[3, 1].Value = "Sırbistan - Makedonya Turu";
            //workSheet.Cells[3, 2].Value = "Zeynep Öztürk";
            //workSheet.Cells[3, 3].Value = "35";

            //var bytes = excel.GetAsByteArray();

            //return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "dosya2.xlsx");
        }

        // Excel dinamik formatında kaydetmek için Models klasörüne DestinationModel ekleyip gerekli propları tanımlıyoruz.
        public List<DestinationModel> DestinationList()
        {
            List<DestinationModel> destinationModels = new List<DestinationModel>();
            using (var c = new Context())
            {
                destinationModels = c.Destinations.Select(x => new DestinationModel
                {
                    City = x.City,
                    DayNight = x.DayNight,
                    Price = x.Price,
                    Capacity = x.Capacity
                }).ToList();
            }
            return destinationModels;
        }

        public IActionResult DestinationExcelReport()
        {
            using (var workBook = new XLWorkbook())
            {
                var workSheet = workBook.Worksheets.Add("Tur Listesi");
                workSheet.Cell(1, 1).Value = "Şehir";
                workSheet.Cell(1, 2).Value = "Konaklama Süresi";
                workSheet.Cell(1, 3).Value = "Fiyat";
                workSheet.Cell(1, 4).Value = "Kapasite";

                int rowCount = 2;
                foreach (var item in DestinationList())
                {
                    workSheet.Cell(rowCount, 1).Value = item.City;
                    workSheet.Cell(rowCount, 2).Value = item.DayNight;
                    workSheet.Cell(rowCount, 3).Value = item.Price;
                    workSheet.Cell(rowCount, 4).Value = item.Capacity;
                    rowCount++;
                }

                using (var stream = new MemoryStream())
                {
                    workBook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "YeniListe.xlsx");
                }
            }
        }
    }
}
