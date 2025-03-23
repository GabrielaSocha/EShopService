using Microsoft.AspNetCore.Mvc;
using EShop.Application;

namespace EShopService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CreditCardController : ControllerBase
    {
        private readonly CreditCardService _service = new();

        [HttpPost("validate")]
        public IActionResult ValidateCard([FromBody] string cardNumber)
        {
            try
            {
                var provider = _service.ValidateCard(cardNumber);
                return Ok(new { status = "Valid", provider });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
