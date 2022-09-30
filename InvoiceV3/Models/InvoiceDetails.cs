using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvoiceV3.Models
{
    public class InvoiceDetails
    {
       
        [Key]
        public int Id { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal SellPrice { get; set; }

        

        //Relation with InvoiceMaster

        [ForeignKey("InvoiceMasterId")]
        public virtual InvoiceMaster InvoiceMaster { get; set; }
        public int InvoiceMasterId { get; set; }


        //Relation With Products

        [ForeignKey("ProductId")]
        public virtual Product Products { get; set; }
        public int ProductId { get; set; }

    }

}
