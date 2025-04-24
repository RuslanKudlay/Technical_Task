using BAL;
using BAL.Interfaces;
using CommonLayer.Customer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TechnicalTask.Controllers
{

    /// <summary>
    /// Контролер для роботи з клієнтами.
    /// </summary>
    /// <remarks>
    /// </remarks>
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        /// <summary>
        /// Отримати клієнтів
        /// 
        /// Приклад запиту:
        /// GET api/Customer/all
        /// </summary>
        /// <returns>Масив клієнтів</returns>
        [HttpGet("all")]
        public async Task<IActionResult> GetCustomers()
        {
            try
            {
                var items = await _customerService.GetCustomersAsync();
                return Ok(items);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Створити клієнта
        /// 
        /// Приклад запиту:
        /// POST api/Customer/create
        /// BODY 
        /// {
        ///    "FullName": "Іван Іванович Бондар",
        ///    "BirthDate": 1990-04-24
        /// }
        /// </summary>
        /// <param name="customerDto">Необхідні поля для створення користувача</param>
        /// <returns></returns>
        [HttpPost("create")]
        public async Task<IActionResult> GetBirthdays([FromBody] CreateCustomerDto customerDto)
        {
            try
            {
                var result = await _customerService.CreateCustomerAsync(customerDto);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        /// <summary>
        /// Повертає список клієнтів, у яких день народження припадає на вказану дату.
        /// 
        /// Приклад запиту:
        /// GET api/Shop/birthdays?date=1985-07-12 00:00:00.0000000
        /// </summary>
        /// <param name="date">Дата, за якою здійснюється пошук (враховуються лише день та місяць).</param>
        /// <returns>Список клієнтів з відповідним днем народження.</returns>

        /// <summary>
        /// GET api/Shop/birthdays?date=1985-07-12 00:00:00.0000000
        /// </summary>
        /// <param name="date">Дата для отримання даних клієнтів</param>
        /// <returns></returns>
        [HttpGet("birthdays")]
        public async Task<IActionResult> GetBirthdays([FromQuery] DateTime date)
        {
            try
            {
                var items = await _customerService.GetBirthdaysAsync(date);

                return Ok(items);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        /// <summary>
        /// Повертає список клієнтів, які здійснювали покупки протягом останніх N днів.
        /// 
        /// Приклад запиту:
        /// GET api/Shop/recent-buyers?days=5
        /// </summary>
        /// <param name="days">Кількість останніх днів, за які потрібно знайти клієнтів з покупками.</param>
        /// <returns>Список клієнтів з датою їх останньої покупки.</returns>
        [HttpGet("recent-buyers")]
        public async Task<IActionResult> GetRecentBuyers([FromQuery] int days)
        {
            try
            {
                var items = await _customerService.GetRecentBuyersAsync(days);

                return Ok(items);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
            
        }

        /// <summary>
        /// Повертає найпопулярніші категорії товарів, які купував конкретний клієнт.
        /// 
        /// 
        /// Приклад запиту:
        /// GET api/Shop/popular-categories?customerId=2
        /// </summary>
        /// <param name="customerId">Ідентифікатор користувача</param>
        /// <returns></returns>
        [HttpGet("popular-categories")]
        public async Task<IActionResult> GetPopularCategories(Guid customerId)
        {
            try
            {
                var items = await _customerService.GetPopularCategoriesAsync(customerId);

                return Ok(items);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
