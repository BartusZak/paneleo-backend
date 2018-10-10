using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using paneleo.Share.Keys;

namespace paneleo.Share.BindingModels.Account
{
    public class RegisterBindingModel
    {
        private string _login;

        [Required(ErrorMessage = Error.user_Login_Username_Required)]
        [StringLength(20, ErrorMessage = Error.user_Login_Username_Length)]
        public string UserName
        {
            get { return _login; }
            set { _login = value.Trim(); }
        }

        [Required(ErrorMessage = Error.user_Login_Password_Required)]
        [StringLength(20, MinimumLength = 8, ErrorMessage = Error.user_Login_Password_Length)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

