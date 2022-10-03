using InvoiceV3.Data;
using InvoiceV3.Models;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceV3.Controllers
{
    public class InvoiceDetailsController : Controller
    {

        private readonly InvoiceDbContext _context;

        public InvoiceDetailsController(InvoiceDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpDelete]
        public JsonResult Delete(int detailId)
        {
            
            InvoiceDetails details = _context.InvoiceDetails.Find(detailId);
            int id = details.InvoiceMasterId;
            InvoiceMaster master = _context.InvoiceMasters.Find(id);
            _context.InvoiceDetails.Remove(details);
            _context.SaveChanges();

            List<InvoiceDetails> detailsAfterRemove = _context.InvoiceDetails.Where(x => x.InvoiceMasterId == id).ToList();

        
            if (master.InvoiceDetails.Count() == 0)
            {
                _context.Remove(master);
                _context.SaveChanges();
            }
            //List<InvoiceDetails> invoiceDetails = _context.InvoiceDetails.Where()
            //_context.SaveChanges();



            return Json("Ok");
        }
    }
}
