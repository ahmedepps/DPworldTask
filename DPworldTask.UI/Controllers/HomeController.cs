using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using DPworldTask.UI.Models;
using System.Data;
using System.Diagnostics;
using ClosedXML.Excel;
using DPworldTask.BusinessLogic.AppServices.Interface;

namespace DPworldTask.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _environment;
        private readonly ICSVService _mapTypeService;
        public static DataTable dt = new DataTable();

        public HomeController(ILogger<HomeController> logger,
            IWebHostEnvironment environment,
            ICSVService MapTypeService)
        {
            _logger = logger;
            _environment = environment;
            _mapTypeService = MapTypeService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(IFormFile postedFile)
        {
            string path = Path.Combine(this._environment.WebRootPath, "Uploads");

            if (postedFile != null)
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                string fileName = Path.GetFileName(postedFile.FileName);
                string filePath = Path.Combine(path, fileName);
                dt = _mapTypeService.ConvertToDataTable(filePath);
                return View(dt);
            }
            return View();
        }

        public IActionResult Export()
        {
            using (XLWorkbook wb = new XLWorkbook())
            {
                dt.TableName = "Excelsheetname";
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ExportedGrid.xlsx");
                }
            }
        }
    }
}