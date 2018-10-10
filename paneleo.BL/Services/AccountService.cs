using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using paneleo.BL.Services.Interfaces;
using paneleo.Share.BindingModels;
using paneleo.Share.BindingModels.Account;
using paneleo.Share.Keys;
using paneleo.Share.Models;
using paneleo.Share.ModelsDto;

namespace paneleo.BL.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly IHttpContextAccessor _httpContext;

        public AccountService(UserManager<User> userManager, IHttpContextAccessor httpContext)
        {
            _userManager = userManager;
            _httpContext = httpContext;
        }

        public async Task<Response<LoginDto>> Login(LoginBindingModel loginModel)
        {
            var result = new Response<LoginDto>();

            result.DtoObject = new LoginDto();

            var user = await _userManager.FindByNameAsync(loginModel.UserName);

            var checkPassword = await _userManager.CheckPasswordAsync(user, loginModel.Password);

            if (user != null && checkPassword)
            {
                var identity = new ClaimsIdentity("Identity.Application");
                identity.AddClaim(new Claim(ClaimTypes.Name, user.Id));

                await _httpContext.HttpContext.SignInAsync("Identity.Application", new ClaimsPrincipal(identity), new AuthenticationProperties { IsPersistent = true });
                return result;
            }

            result.Errors.Add(Error.UserWrongLoginOrPassword);
            return result;
        }

        public async Task<Response<RegisterDto>> Register(RegisterBindingModel registerModel)
        {
            var result = new Response<RegisterDto>();

            var user = new User()
            {
                Id = registerModel.UserName,
                PasswordHash = registerModel.Password,
                UserName= registerModel.UserName,
            };
            var test  = await _userManager.CreateAsync(user, registerModel.Password);
            
            return result;
        }

    }
}
