using Contract.Services;
using Contract.ViewModel.Order.Kit;
using Contract.ViewModel.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KitRulesController : ControllerBase
    {

        private readonly IKitRulesService _kitRuleservice;
        public KitRulesController(IKitRulesService kitRuleservice)
        {
            _kitRuleservice = kitRuleservice;
        }

        [HttpPost("AddKitRules")]
        public IActionResult AddKitRules([FromBody]CreateKitRulesDto kitRulesDto)
        {

            try
            {
                if (_kitRuleservice.AddKitRules(kitRulesDto))
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