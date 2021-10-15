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
        [StringLength(30, ErrorMessage = "{0} musi zawierać minimum {2} znaków", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Hasło:")]
        public string Password { get; set; }

        [Display(Name = "Zapamiętaj mnie")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required(ErrorMessage ="Proszę podać imię")]
        [Display(Name = "Imię:")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Proszę podać nazwisko")]
        [Display(Name = "Nazwisko:")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Proszę podać ulicę oraz nr domu/mieszkania")]
        [Display(Name = "Ulica i nr domu/mieszkania:")]
        public string StreetAndNo { get; set; }

        [Required(ErrorMessage = "Proszę podać miasto oraz kod pocztowy")]
        [Display(Name = "Miasto i kod pocztowy:")]
        public string CityAndPostCode { get; set; }

        [Required(ErrorMessage = "Proszę podać numer telefonu")]
        [RegularExpression(@"(\+\d{2})*[\d\s-]+", ErrorMessage = "Błędny format numeru telefonu.")]
        [Display(Name = "Numer telefonu:")]
        public int PhoneNumber { get; set; }

        [Required(ErrorMessage ="Proszę podać e-mail")]
        [EmailAddress]
        [Display(Name = "E-mail:")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Proszę podać hasło")]
        [StringLength(30,ErrorMessage = "{0} musi zawierać minimum {2} znaków, co najmniej jeden znak inny niż litera lub cyfra,co najmniej jedną cyfrę („0”-„9”), co najmniej jedną wielką literę („A”-„Z”).”", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Hasło:")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Powtórz hasło:")]
        [Compare("Password", ErrorMessage ="Podane hasło nie jest identyczne")]
        public string ConfirmPassword { get; set; }
    }
}