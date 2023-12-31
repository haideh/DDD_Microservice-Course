using Contract.Services;
using Contract.ViewModel.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userservice;
        public UserController(IUserService userservice)
        {
            _userservice = userservice;
        }
       
        [HttpPost("Register")]
        public IActionResult RegisterUser([FromBody] CreateUserDto userDto)
        {
            
            try
            {
                if (_userservice.Register(userDto))
                    return Ok();
                else
                    return BadRequest("داده تکراری است");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }
        [HttpGet("LoadProfile/{id}")]
        public IActionResult LoadProfile(int id)
        {

            try
            {
                var result = _userservice.GetUserById(id);
                return Ok(result);  
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        [HttpGet("LoadCountryKitByUserId/{userId}")]
        public IActionResult LoadCountryKitByUserId(int userId)
        {

            try
            {
                var result = _userservice.GetCountryKitByUserId(userId);
                if(result == null)
                    return BadRequest("داده وجود ندارد ");
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

    }
}