using System.Threading.Tasks;
using paneleo.Share.BindingModels;
using paneleo.Share.BindingModels.Account;
using paneleo.Share.ModelsDto;

namespace paneleo.BL.Services.Interfaces
{
    public interface IAccountService
    {
        Task<Response<LoginDto>> Login(LoginBindingModel loginModel);

        Task<Response<RegisterDto>> Register(RegisterBindingModel registerModel);
    }
}
