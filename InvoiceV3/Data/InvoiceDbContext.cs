using InvoiceV3.Models;
using Microsoft.EntityFrameworkCore;

namespace InvoiceV3.Data
{
    public class InvoiceDbContext :DbContext
    {
        public InvoiceDbContext()
        {

        }

        public InvoiceDbContext(DbContextOptions<InvoiceDbContext> options):base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.Entity<Product>().Property(p => p.Price)
                        .HasColumnType("decimal(18,2)");
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }

        public virtual DbSet<InvoiceMaster> InvoiceMasters { get; set; }

        public virtual DbSet<InvoiceDetails> InvoiceDetails { get; set; }
    }
}
