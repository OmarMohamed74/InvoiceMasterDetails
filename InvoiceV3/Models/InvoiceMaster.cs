using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvoiceV3.Models
{
    public class InvoiceMaster
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string InvoiceSerial { get; set; }
        public DateTime Date { get; set; }

        


        // Relation with InvoiceDetails

        public virtual List<InvoiceDetails> InvoiceDetails { get; set; }

        // Relation with Customers
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }
        public int CustomerId { get; set; }





    }
}
