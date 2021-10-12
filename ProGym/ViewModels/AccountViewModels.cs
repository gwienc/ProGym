using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProGym.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Proszę podać e-mail")]
        [EmailAddress]
        public string Email { get; set; }

        [Required (ErrorMessage ="Proszę podać hasło")]
        public string Password { get; set; }

        [Display(Name = "Zapamiętaj mnie")]
        public bool RememberMe { get; set; }
    }
}