using BAL.Interfaces;
using CommonLayer.Product;
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
    public class ProductService : IProductService
    {
        private readonly IApplicationDbContext _dbContext;

        public ProductService(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> CreateProductAsync(CreateProductDto productDto)
        {
            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = productDto.Name,
                Category = productDto.Category,
                Article = productDto.Article,
                Price = productDto.Price,
                DateCreate = DateTime.Now,
            };
            await _dbContext.Products.AddAsync(product);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<List<GetProductsDto>> GetProductsAsync()
        {
            return await _dbContext.Products
                .AsNoTracking()
                .Select(p => new GetProductsDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Article = p.Article,
                    Price = p.Price
                })
                .ToListAsync();
        }
    }
}
