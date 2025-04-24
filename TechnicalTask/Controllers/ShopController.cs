using BAL.Interfaces;
using DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TechnicalTask.Controllers
{

    /// <summary>
    /// Контролер для роботи з магазинами, клієнтами та їх покупками.
    /// </summary>
    /// <remarks>
    /// Містить методи для отримання клієнтів, товарів, покупок, категорій та іншої супутньої інформації.
    /// </remarks>
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private readonly IShopService _shopService;

        public ShopController(IShopService shopService)
        {
            _shopService = shopService;
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
            var items = await _shopService.GetBirthdaysAsync(date);

            return Ok(items);
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
            var items = await _shopService.GetRecentBuyersAsync(days);

            return Ok(items);
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
        public async Task<IActionResult> GetPopularCategories(int customerId)
        {
            var items = await _shopService.GetPopularCategoriesAsync(customerId);

            return Ok(items);
        }
    }
}
