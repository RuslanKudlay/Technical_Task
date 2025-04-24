using BAL.Interfaces;
using CommonLayer.DTOs;
using DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class ShopService : IShopService
    {
        private readonly IApplicationDbContext _dbContext;
        public ShopService(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
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

        public async Task<List<PopularCustomerCategotyDto>> GetPopularCategoriesAsync(int customerId)
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
                .Where(c => c.Purchases.Any(p => p.Date >= sinceDate))
                .Select(c => new DayRecentCustomerDto
                {
                    CustomerId = c.Id,
                    FullName = c.FullName,
                    LastPurchaseDate = c.Purchases
                        .Where(p => p.Date >= sinceDate)
                        .OrderByDescending(p => p.Date)
                        .Select(p => p.Date)
                        .FirstOrDefault()
                })
                .ToListAsync();
        }
    }
}
