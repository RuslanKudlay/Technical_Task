using CommonLayer.Customer;
using CommonLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Interfaces
{
    public interface ICustomerService
    {
        Task<List<GetCustomersDto>> GetCustomersAsync();
        Task<bool> CreateCustomerAsync(CreateCustomerDto customerDto);
        Task<List<CustomerBirthdayDto>> GetBirthdaysAsync(DateTime date);
        Task<List<DayRecentCustomerDto>> GetRecentBuyersAsync(int days);
        Task<List<PopularCustomerCategotyDto>> GetPopularCategoriesAsync(Guid customerId);
    }
}
