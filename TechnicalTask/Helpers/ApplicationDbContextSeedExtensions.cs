using DAL.Entities;
using DAL;
using Microsoft.EntityFrameworkCore;

namespace TechnicalTask.Helpers
{
    public static class ApplicationDbContextSeedExtensions
    {
        public static Task Seed(this ApplicationDbContext context)
        {

            var customers = new List<Customer>
            {
                new() { FullName = "Іван Іванов", BirthDate = new DateTime(1990, 4, 24), RegistrationDate = DateTime.UtcNow.AddMonths(-3) },
                new() { FullName = "Марія Петренко", BirthDate = new DateTime(1985, 7, 12), RegistrationDate = DateTime.UtcNow.AddMonths(-2) },
                new() { FullName = "Олег Шевченко", BirthDate = new DateTime(1993, 4, 24), RegistrationDate = DateTime.UtcNow.AddMonths(-1) }
            };
            context.Customers.AddRange(customers);

            var products = new List<Product>
            {
                new() { Name = "Хліб", Category = "Харчі", Article = "BRD-001", Price = 20.50m },
                new() { Name = "Молоко", Category = "Харчі", Article = "MLK-002", Price = 35.00m },
                new() { Name = "Сік", Category = "Напої", Article = "JUI-003", Price = 45.75m },
                new() { Name = "Шампунь", Category = "Гігієна", Article = "SHP-004", Price = 89.99m }
            };
            context.Products.AddRange(products);

            context.SaveChanges();

            var purchases = new List<Purchase>
            {
                new()
                {
                    Date = DateTime.UtcNow.AddDays(-2),
                    CustomerId = customers[0].Id,
                    Items = new List<PurchaseItem>
                    {
                        new() { ProductId = products[0].Id, Quantity = 2 },
                        new() { ProductId = products[1].Id, Quantity = 1 }
                    }
                },
                new()
                {
                    Date = DateTime.UtcNow.AddDays(-1),
                    CustomerId = customers[1].Id,
                    Items = new List<PurchaseItem>
                    {
                        new() { ProductId = products[2].Id, Quantity = 3 },
                        new() { ProductId = products[3].Id, Quantity = 1 }
                    }
                }
            };

            foreach (var purchase in purchases)
            {
                purchase.TotalPrice = purchase.Items
                    .Sum(item => item.Quantity * products.First(p => p.Id == item.ProductId).Price);
            }

            context.Purchases.AddRange(purchases);
            context.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
