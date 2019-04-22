﻿using System.ComponentModel.DataAnnotations;

namespace WebApiJWT.ViewsModels
{
    public class LoginViewModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
