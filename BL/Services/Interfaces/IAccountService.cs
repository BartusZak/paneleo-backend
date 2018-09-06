using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using paneleo.Share.BindingModels;
using paneleo.Share.ModelsDto;
using Microsoft.AspNetCore.Identity;

namespace paneleo.BL.Services.Interfaces
{
    public interface IAccountService
    {
        Task<Response<LoginDto>> Login(LoginBindingModel loginModel);
        Task LogOut();
    }
}
