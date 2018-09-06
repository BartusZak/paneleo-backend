using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using paneleo.BL.Services.Interfaces;
using paneleo.Share.ModelsDto;
using paneleo.Share.Models;
using Microsoft.AspNetCore.Mvc;
using paneleo.Share.BindingModels.Account;
using paneleo.Share.ModelsDto.Account;

namespace paneleo.BL.Services
{
    public class AccountService : IAccountService
    {

        public AccountService()
        {
        }

        public async Task<Response<RegisterDto>> Login(LoginBindingModel loginModel)
        {
            var result = new Response<RegisterDto>();

            return result;
        }

        public async Task<Response<RegisterDto>> Register(RegisterBindingModel loginModel)
        {
            var result = new Response<RegisterDto>();
            return result;
        }

    }
}
