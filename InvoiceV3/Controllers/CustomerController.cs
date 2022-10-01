using InvoiceV3.Data;
using InvoiceV3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InvoiceV3.Controllers
{
    public class CustomerController : Controller
    {
        private readonly InvoiceDbContext _context;
        public CustomerController(InvoiceDbContext context)
        {
            _context = context;
        }
        public IActionResult InvoiceMasterByCustomer(string customerName)
        {
            List<InvoiceMaster> invoiceMasters = _context.InvoiceMasters.Include(x=>x.Customer)
                .Where(x=>x.Customer.CustromerName == customerName).ToList();



            return PartialView("_invoiceMasterByName", invoiceMasters);
        }
    }
}
