using InvoiceV3.Models;

namespace InvoiceV3.ViewModels
{
    public class InvoiceViewModel
    {
        public string InvoiceSerial { get; set; }
        public DateTime Date { get; set; }
        public int CustomerId{ get; set; }

        public decimal SellPrice { get; set; }

        public int Quantity { get; set; }

        public int productId { get; set; }









    }
}
