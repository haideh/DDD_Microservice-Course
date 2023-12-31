using Contract.Services;
using Contract.ViewModel.Order.Discount;
using Contract.ViewModel.Order.Kit;
using Contract.ViewModel.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {

        private readonly IDiscountService _discountService;
        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpPost("AddDiscount")]
        public IActionResult AddDiscount([FromBody]CreateDiscountDto discountDto)
        {

            try
            {
                if (_discountService.AddDiscount(discountDto))
                    return Ok();
                else
                    return BadRequest("خطا در انجام عملیات");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

    }
}