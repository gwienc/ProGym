using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProGym.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public string UserId { get; set; }

        [Display(Name = "Imię:")]
        [Required(ErrorMessage = "Proszę podać imię")]
        public string FirstName { get; set; }

        [Display(Name = "Nazwisko:")]
        [Required(ErrorMessage = "Proszę podać nazwisko")]
        public string LastName { get; set; }

        [Display(Name = "Ulica i nr domu/mieszkania:")]
        [Required(ErrorMessage = "Proszę podać ulicę oraz nr domu/mieszkania")]
        public string Address { get; set; }

        [Display(Name = "Miasto i kod pocztowy:")]
        [Required(ErrorMessage = "Proszę podać miasto oraz kod pocztowy")]
        public string CodeAndCity { get; set; }

        [RegularExpression(@"(\+\d{2})*[\d\s-]+",
            ErrorMessage = "Błędny format numeru telefonu.")]
        [Display(Name = "Numer telefonu:")]
        [Required(ErrorMessage = "Proszę podać numer telefonu")]
        public string PhoneNumber { get; set; }

        [EmailAddress(ErrorMessage = "Błędny format adresu e-mail.")]
        [Required(ErrorMessage = "Proszę podać e-mail")]
        [Display(Name = "E-mail:")]
        public string Email { get; set; }

        [Display(Name = "Komentarz")]
        public string Comment { get; set; }
        public DateTime DateCreated { get; set; }
        public OrderState OrderState { get; set; }
        public decimal TotalPrice { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public virtual ApplicationUser User { get; set; }
    }

    public enum OrderState
    {
        [Display(Name = "W przygotowaniu")]
        InProgress,

        [Display(Name = "Do odbioru")]
        Completed,

        [Display(Name = "Odebrane")]
        Received
    }
}