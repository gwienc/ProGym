using System.ComponentModel.DataAnnotations;

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
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage ="Proszę podać e-mail")]
        [EmailAddress]
        [Display(Name = "E-mail:")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Proszę podać hasło")]
        [RegularExpression(@"((?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&*()_]).{6,})",ErrorMessage = "Hasło musi zawierać co najmniej jeden znak specjalny,co najmniej jedną cyfrę („0”-„9”), co najmniej jedną wielką i małą literę („A”-„Z”) oraz minimum 6 znaków")]
        [StringLength(30,ErrorMessage = "{0} musi zawierać minimum {2} znaków", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Hasło:")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Powtórz hasło:")]
        [Compare("Password", ErrorMessage ="Podane hasło nie jest identyczne")]
        public string ConfirmPassword { get; set; }
    }
}