using BAL;
using BAL.Interfaces;
using CommonLayer.Customer;
using CommonLayer.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TechnicalTask.Controllers
{
    /// <summary>
    /// Контролер для роботи з продуктами.
    /// </summary>
    /// <remarks>
    /// </remarks>
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Отримати продукти
        /// 
        /// Приклад запиту:
        /// GET api/Product/all
        /// </summary>
        /// <returns>Масив продуктів</returns>
        [HttpGet("all")]
        public async Task<IActionResult> GetCustomers()
        {
            try
            {
                var items = await _productService.GetProductsAsync();
                return Ok(items);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Створити продукт
        /// 
        /// Приклад запиту:
        /// POST api/Product/create
        /// BODY 
        /// {
        ///    "Name": "Хліб",
        ///    "Category": "Харчі",
        ///    "Article": "45245",
        ///    "Price": 25.5
        /// }
        /// </summary>
        /// <param name="productDto">Необхідні поля для створення продукта</param>
        /// <returns></returns>
        [HttpPost("create")]
        public async Task<IActionResult> GetBirthdays([FromBody] CreateProductDto productDto)
        {
            try
            {
                var result = await _productService.CreateProductAsync(productDto);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
