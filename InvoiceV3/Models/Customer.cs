using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvoiceV3.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CustromerName { get; set; }

       


        // Relation with InvoiceMaster
        public virtual List<InvoiceMaster> InvoiceMasters { get; set; }
      

    }
}
