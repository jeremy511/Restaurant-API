﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Application.ViewModels.Users
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "*Debes colocar el nombre de usuario.*")]
        [DataType(DataType.Text)]
        private string UserName { get; set; }

        [Required(ErrorMessage = "*Debes colocar la contraseña.*")]
        [DataType(DataType.Password)]
        private string Password { get; set; }
        public bool HasError { get; set; }
        public string Error { get; set; }
    }
}
