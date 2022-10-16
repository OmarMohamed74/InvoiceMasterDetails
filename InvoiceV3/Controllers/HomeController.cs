using InvoiceV3.Data;
using InvoiceV3.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace InvoiceV3.Controllers
{
    public class HomeController : Controller


    {
        private readonly ILogger<HomeController> _logger;


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return Redirect("http://omarmohamed/Reports2022/report/TotalInvoice");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}