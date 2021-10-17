using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProGym.Models
{
    public class UserData
    {
        
        [Display(Name = "Imię:")]
        public string FirstName { get; set; }
        
        [Display(Name = "Nazwisko:")]
        public string LastName { get; set; }
        
        [Display(Name = "Ulica i nr domu/mieszkania:")]
        public string Address { get; set; }
        
        [Display(Name = "Miasto i kod pocztowy:")]
        public string CodeAndCity { get; set; }

        
        [RegularExpression(@"(\+\d{2})*[\d\s-]+",
            ErrorMessage = "Błędny format numeru telefonu.")]
        [Display(Name = "Numer telefonu:")]
        public string PhoneNumber { get; set; }

        [EmailAddress(ErrorMessage = "Błędny format adresu e-mail.")]
        [Display(Name = "E-mail:")]
        public string Email { get; set; }
    }
}