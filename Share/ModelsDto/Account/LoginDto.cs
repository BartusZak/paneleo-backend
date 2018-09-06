using System.Collections.Generic;

namespace paneleo.Share.ModelsDto.Account
{
    public class LoginDto : DtoBaseModel
    {
        public string Login { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; }
    }
}
