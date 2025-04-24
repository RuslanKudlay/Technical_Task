using CommonLayer.Customer;
using CommonLayer.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Interfaces
{
    public interface IProductService
    {
        Task<List<GetProductsDto>> GetProductsAsync();
        Task<bool> CreateProductAsync(CreateProductDto productDto);
    }
}
