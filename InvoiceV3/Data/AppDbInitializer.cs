
using InvoiceV3.Models;

namespace InvoiceV3.Data
{
    public class AppDbInitializer
    {
        /* Seeding data to database if there are nothing in specific tabels,
         Fill the product details to be used in list of product */
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<InvoiceDbContext>();

                context.Database.EnsureCreated();

                //Customers

                if (!context.Customers.Any())
                {
                    context.Customers.AddRange(new List<Customer>()
                    {
                        new Customer()
                        {

                            CustromerName = "Salem",

                        },

                       new Customer()
                        {

                            CustromerName = "Khaled",

                        },
                       new Customer()
                        {

                            CustromerName = "Eed",

                        },
                       new Customer()
                        {

                            CustromerName = "Ahmed",

                        },
                       new Customer()
                        {

                            CustromerName = "Mahmoud",

                        },
                       new Customer()
                        {

                            CustromerName = "Omar",

                        },
                    });
                    context.SaveChanges();
                }

                if (!context.Products.Any())
                    {
                        context.Products.AddRange(new List<Product>()
                    {
                        new Product()
                        {

                            Name = "PS4",
                            Price =9450

                        },

                       new Product()
                        {

                            Name = "Motherboard",
                            Price =2500

                        },
                       new Product()
                        {

                            Name = "Logitech Mouse",
                            Price =800

                        },
                       new Product()
                        {

                            Name = "Mousepad",
                            Price =500

                        },
                       new Product()
                        {

                            Name = "Msi laptop",
                            Price =15000

                        },
                       new Product()
                        {

                            Name = "ThinkPad",
                            Price =13000

                        },
                    });
                        context.SaveChanges();
                    }
                }
            }
        }
    }

  
