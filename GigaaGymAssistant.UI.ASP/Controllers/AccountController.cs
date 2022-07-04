using GigaaGymAssistant.Domain.Common.Models.User;
using GigaaGymAssistant.Interfaces.Facades;
using Microsoft.AspNetCore.Mvc;

namespace GigaaGymAssistant.UI.ASP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountFcd _accountFcd;

        public AccountController(IAccountFcd accountFcd)
        {
            _accountFcd = accountFcd;
        }

        [HttpPost("register")]
        public ActionResult RegisterUser([FromBody] RegisterDTO registerDTO)
        {
            return Ok(_accountFcd.RegisterUser(registerDTO));
        }

        [HttpPost("login")]
        public ActionResult LoginUser([FromBody] LoginDTO loginDTO)
        {
            return Ok(_accountFcd.LoginUser(loginDTO));
        }
    }
}
