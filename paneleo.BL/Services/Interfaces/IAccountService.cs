using System;
using System.Threading.Tasks;
using paneleo.Share.BindingModels.Account;
using paneleo.Share.ModelsDto;
using paneleo.Share.ModelsDto.Account;

namespace paneleo.BL.Services.Interfaces
{
    public interface IAccountService
    {
        Task<Response<RegisterDto>> Login(LoginBindingModel loginModel);

        Task<Response<RegisterDto>> Register(RegisterBindingModel registerModel);
        //Task LogOut();
    }
}
