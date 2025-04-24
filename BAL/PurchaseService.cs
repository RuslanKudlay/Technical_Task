using BAL.Interfaces;
using CommonLayer.Purchase;
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
    public class PurchaseService : IPurchaseService
    {
        private readonly IApplicationDbContext _dbContext;

        public PurchaseService(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> DoPurchaseAsync(PurchaseDto purchaseDto)
        {
            var productIds = purchaseDto.PurchaseItemDtos.Select(x => x.ProductId).ToList();
            var products = await _dbContext.Products.Where(p => productIds.Contains(p.Id)).ToListAsync(); ;

            var purchaseId = Guid.NewGuid();
            var purchase = new Purchase
            {
                Id = purchaseId,
                CustomerId = purchaseDto.CustomerId,
                DateCreate = DateTime.Now,
                Items = purchaseDto.PurchaseItemDtos
                    .Select(c => new PurchaseItem
                    {
                        Id = Guid.NewGuid(),
                        ProductId = c.ProductId,
                        Quantity = c.Quantity,
                        PurchaseId = purchaseId,
                        DateCreate= DateTime.Now,
                    })
                    .ToList()
            };
            purchase.TotalPrice = purchase.Items.Sum(item => item.Quantity * products.First(p => p.Id == item.ProductId).Price);

            await _dbContext.Purchases.AddAsync(purchase);
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
