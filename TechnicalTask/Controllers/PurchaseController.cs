using BAL;
using BAL.Interfaces;
using CommonLayer.Customer;
using CommonLayer.Purchase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TechnicalTask.Controllers
{

    /// <summary>
    /// Контролер для роботи з покупками.
    /// </summary>
    /// <remarks>
    /// </remarks>
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseService _purchaseService;
        public PurchaseController(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        }

        /// <summary>
        /// Зробити покупку
        /// 
        /// Приклад запиту:
        /// POST api/Purchase/create
        /// BODY 
        /// {
        ///    "CustomerId": 002AE995-A979-4993-9AC8-429899A33444,
        ///    "PurchaseItemDtos": [
        ///         {
        ///           "ProductId": ACC4C9D3-7563-4AFB-9E5F-32C815399E5E,
        ///           "Quantity": 4
        ///         }
        ///    ]
        /// }
        /// </summary>
        /// <param name="purchaseDto">Необхідні поля для створення покупки</param>
        /// <returns></returns>
        [HttpPost("create")]
        public async Task<IActionResult> GetBirthdays([FromBody] PurchaseDto purchaseDto)
        {
            try
            {
                var result = await _purchaseService.DoPurchaseAsync(purchaseDto);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
