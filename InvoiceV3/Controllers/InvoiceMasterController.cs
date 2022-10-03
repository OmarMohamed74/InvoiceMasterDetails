using InvoiceV3.Data;
using InvoiceV3.Data.PagedList;
using InvoiceV3.Models;
using InvoiceV3.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace InvoiceV3.Controllers
{
    public class InvoiceMasterController : Controller
    {
        private readonly InvoiceDbContext _context;
        public InvoiceMasterController(InvoiceDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int Page = 1)
        {
            List<InvoiceMaster> invoiceMasters = _context.InvoiceMasters.Include(x => x.Customer).ToList();

            // Pages List 
            const int PageSize = 10;

            int ResultCount = invoiceMasters.Count();

            var Pages = new Pages(ResultCount, Page, PageSize);

            int ResultPage = (Page - 1) * PageSize;

            // Return into View

            var data = invoiceMasters.Skip(ResultPage).Take(Pages.PageSize).ToList();

            // Working On View

            ViewBag.DataView = Pages;

            return View(data);
        }

        public IActionResult Create()
        {
            List<Customer> customerList = _context.Customers.ToList();
            ViewBag.CustomerList = customerList;

            List<Product> productList = _context.Products.ToList();
            ViewBag.ProductList = productList;

            List<InvoiceDetails> invoiceDetailsList = _context.InvoiceDetails.ToList();

            return View(invoiceDetailsList);
        }

        public IActionResult Details(int Id)
        {
            InvoiceMaster invoiceMaster = _context.InvoiceMasters
                  .Include(x => x.Customer)
                  .Include(x => x.InvoiceDetails)
                  .ThenInclude(x => x.Products)
                  .Where(x => x.Id == Id).FirstOrDefault();

            return View(invoiceMaster);

        }

 
        public IActionResult Update(int id)
        {
            InvoiceMaster invoiceMaster = _context.InvoiceMasters
                                                        .Include(x => x.Customer)
                                                        .Include(x => x.InvoiceDetails)
                                                        .ThenInclude(x => x.Products)
                                                        .Where(x => x.Id == id).FirstOrDefault();

            List<Customer> customerList = _context.Customers.ToList();
            ViewBag.CustomerList = customerList;

            List<Product> productList = _context.Products.ToList();
            ViewBag.ProductList = productList;

            return View(invoiceMaster);
        }

        [HttpPost]
        public JsonResult Update(int id,List<InvoiceDetails> details,InvoiceViewModel master)
        {
                var invoiceMaster = _context.InvoiceMasters.Find(id);
           
            invoiceMaster.InvoiceSerial = master.InvoiceSerial;
            invoiceMaster.Date = master.Date;
            invoiceMaster.CustomerId = master.CustomerId;
            _context.SaveChanges();

            List<InvoiceDetails> detailsList = _context.InvoiceDetails.Where(x=>x.InvoiceMasterId == id).ToList();
            _context.InvoiceDetails.RemoveRange(detailsList);
            invoiceMaster.InvoiceDetails.AddRange(details);
            _context.SaveChanges();

            return Json("Ok");
        }


        public IActionResult Delete(int id)
        {
            List<InvoiceDetails> invoiceDetails = _context.InvoiceDetails.Where(x => x.InvoiceMasterId == id).ToList();

            _context.InvoiceDetails.RemoveRange(invoiceDetails);

            //foreach (var item in invoiceDetails)
            //{
            //    _context.InvoiceDetails.Remove(item);
            //}
            //_context.SaveChanges();

            InvoiceMaster master = _context.InvoiceMasters.FirstOrDefault(x => x.Id == id);
            _context.Remove(master);
            _context.SaveChanges();


            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult saveInvoice(List<InvoiceViewModel> invoice, InvoiceViewModel master)
        {
            InvoiceMaster invoiceMaster = new InvoiceMaster();

            invoiceMaster.InvoiceSerial = master.InvoiceSerial;
            invoiceMaster.CustomerId = master.CustomerId;
            invoiceMaster.Date = master.Date;
            List<InvoiceDetails> Details = new List<InvoiceDetails>();

            foreach (var invoiceD in invoice)
            {
                Details.Add(new InvoiceDetails
                {

                    Quantity = invoiceD.Quantity,
                    SellPrice = invoiceD.SellPrice,
                    ProductId = invoiceD.productId


                });
            }
            invoiceMaster.InvoiceDetails = Details;


            _context.Add(invoiceMaster);
            _context.SaveChanges();


            return Json("");
        }


        [HttpGet]
        public JsonResult GetPriceOfProduct(int id)
        {
            var Price = _context.Products
                .Where(x => x.Id == id)
                .Select(y => y.Price).FirstOrDefault();

            return Json(Price);
        }
    }
    }

