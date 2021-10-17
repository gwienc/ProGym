using ProGym.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProGym.Models
{
    public class ManageCredentialsViewModel
    {
        public bool HasPassword { get; set; }
        public ChangePasswordViewModel ChangePasswordViewModel { get; set; }
        public ProGym.Controllers.ManageController.ManageMessageId? Message { get; set; }
        public bool ShowRemoveButton { get; set; }

        public UserData UserData { get; set; }
    }


    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Aktualne hasło")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "{0} musi zawierać minimum {2} znaków, co najmniej jeden znak inny niż litera lub cyfra,co najmniej jedną cyfrę („0”-„9”), co najmniej jedną wielką literę („A”-„Z”).”", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Nowe hasło")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Powtórz nowe hasło:")]
        [Compare("NewPassword", ErrorMessage = "Podane hasło nie jest identyczne")]
        public string ConfirmPassword { get; set; }
    }
}