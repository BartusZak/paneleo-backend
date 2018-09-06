﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace paneleo.Share.BindingModels
{
    public class RegisterBindingModel
    {
        public string _login;

        public string Login
        {
            get { return _login; }
            set { _login = value.Trim(); }
        }

        public string Password { get; set; }
    }
}