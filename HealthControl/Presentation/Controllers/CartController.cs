using Contract.Services;
using Contract.ViewModel.Order.Cart;
using Contract.ViewModel.Order.Discount;
using Contract.ViewModel.Order.Kit;
using Contract.ViewModel.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {

        private readonly ICartService _cartService;
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpPost("AddCart")]
        public IActionResult AddCart([FromBody]CreateCartDto cartDto)
        {

            try
            {
                if (_cartService.AddCart(cartDto))
                    return Ok();
                else
                    return BadRequest("خطا در انجام عملیات");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }


        [HttpGet("GetCart/{id}")]
        public IActionResult GetCart(int id)
        {

            try
            {
                var result = _cartService.GetCartById(id);
                if (result != null)
                    return Ok(result);
                else
                    return BadRequest("داده چیدا نشد");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

    }
}