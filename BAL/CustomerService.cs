using BAL.Interfaces;
using CommonLayer.Customer;
using CommonLayer.DTOs;
using DAL;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class CustomerService : ICustomerService
    {
        private readonly IApplicationDbContext _dbContext;
        public CustomerService(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> CreateCustomerAsync(CreateCustomerDto customerDto)
        {
            var customer = new Customer
            {
                Id = Guid.NewGuid(),
                FullName = customerDto.FullName,
                BirthDate = customerDto.BirthDate,
                RegistrationDate = DateTime.Now,
                DateCreate = DateTime.Now,
            };
            await _dbContext.Customers.AddAsync(customer);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<List<CustomerBirthdayDto>> GetBirthdaysAsync(DateTime date)
        {
            return await _dbContext.Customers
            .Where(c => c.BirthDate.Month == date.Month && c.BirthDate.Day == date.Day)
            .Select(c => new CustomerBirthdayDto
            {
                CustomerId = c.Id,
                FullName = c.FullName
            })
            .ToListAsync();
        }

        public async Task<List<GetCustomersDto>> GetCustomersAsync()
        {
            return await _dbContext.Customers
                .AsNoTracking()
                .Select(c => new GetCustomersDto
                {
                    Id = c.Id,
                    FullName = c.FullName,
                })
                .ToListAsync();
        }

        public async Task<List<PopularCustomerCategotyDto>> GetPopularCategoriesAsync(Guid customerId)
        {
            return await _dbContext.PurchaseItems
            .Where(pi => pi.Purchase.CustomerId == customerId)
            .GroupBy(pi => pi.Product.Category)
            .Select(g => new PopularCustomerCategotyDto
            {
                Category = g.Key,
                TotalQuantity = g.Sum(x => x.Quantity)
            })
            .ToListAsync();
        }

        public async Task<List<DayRecentCustomerDto>> GetRecentBuyersAsync(int days)
        {
            var sinceDate = DateTime.UtcNow.AddDays(-days);

            return await _dbContext.Customers
                .Where(c => c.Purchases.Any(p => p.DateCreate >= sinceDate))
                .Select(c => new DayRecentCustomerDto
                {
                    CustomerId = c.Id,
                    FullName = c.FullName,
                    LastPurchaseDate = c.Purchases
                        .Where(p => p.DateCreate >= sinceDate)
                        .OrderByDescending(p => p.DateCreate)
                        .Select(p => p.DateCreate)
                        .FirstOrDefault()
                })
                .ToListAsync();
        }
    }
}
