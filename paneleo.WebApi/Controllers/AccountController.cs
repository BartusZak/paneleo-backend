using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using paneleo.BL.Services.Interfaces;
using paneleo.Share.BindingModels;
using paneleo.Share.BindingModels.Account;

namespace paneleo.WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginBindingModel loginModel)
        {
            var result = await _accountService.Login(loginModel);

            if (result.ErrorOccurred)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterBindingModel registerModel)
        {
            var result = await _accountService.Register(registerModel);

            if (result.ErrorOccurred)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}