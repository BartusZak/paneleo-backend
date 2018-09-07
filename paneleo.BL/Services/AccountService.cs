using System.Threading.Tasks;
using paneleo.BL.Services.Interfaces;
using paneleo.Share.BindingModels;
using paneleo.Share.ModelsDto;

namespace paneleo.BL.Services
{
    public class AccountService : IAccountService
    {

        public AccountService()
        {
        }

        public async Task<Response<LoginDto>> Login(LoginBindingModel loginModel)
        {
            var result = new Response<LoginDto>();

            return result;
        }

        public async Task<Response<RegisterDto>> Register(RegisterBindingModel loginModel)
        {
            var result = new Response<RegisterDto>();
            return result;
        }

    }
}
