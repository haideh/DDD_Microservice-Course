using Contract.Services;
using Contract.ViewModel.Order.Kit;
using Contract.ViewModel.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KitController : ControllerBase
    {

        private readonly IKitService _kitservice;
        public KitController(IKitService kitservice)
        {
            _kitservice = kitservice;
        }

        [HttpPost("AddKit")]
        public IActionResult AddKit([FromBody] CreateKitDto kitDto)
        {

            try
            {
         

                if (_kitservice.AddKit(kitDto))
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