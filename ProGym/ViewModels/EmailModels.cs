using Postal;
using ProGym.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProGym.ViewModels
{
    public class OrderConfirmationEmail : Email
    {
        public string To { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public int OrderNumber { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public string CoverPath { get; set; }
    }

    public class OrderPreparedEmail : Email
    {
        public string To { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public int OrderNumber { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public string CoverPath { get; set; }
    }

    public class OrderReceivedEmail : Email
    {
        public string To { get; set; }
        public string Name { get; set; }
        public int OrderNumber { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public string CoverPath { get; set; }

    }

    public class TicketConfirmationEmail : Email
    {
        public string To { get; set; }
        public int TicketID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string TicketName { get; set; }
        public DateTime ExpirationDate { get; set; }
        public PeriodOfValidity PeriodOfValidity { get; set; }
    }
    public class TicketConfirmationEmailActive : Email
    {
        public string To { get; set; }
        public int TicketID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string TicketName { get; set; }
        public DateTime ExpirationDate { get; set; }
        public PeriodOfValidity PeriodOfValidity { get; set; }
    }

    public class TicketInactiveInformationEmail : Email
    {
        public string To { get; set; }
        public int TicketID { get; set; }
        public string Name { get; set; }
        public string TicketName { get; set; }
        public DateTime ExpirationDate { get; set; }
    }

    public class ContactMessageEmail : Email
    {
        public string To { get; set; }
        
        [Required(ErrorMessage = "Proszę podać swoje dane")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Proszę podać numer telefonu")]
        [StringLength(9,MinimumLength =9,ErrorMessage ="Błędny format telefonu")]
        [RegularExpression(@"(\+\d{2})*[\d\s-]+", ErrorMessage = "Błędny format numeru telefonu.")]
        public string PhoneNumber { get; set; }
        
        [Required(ErrorMessage = "Proszę podać e-mail")]
        [EmailAddress]
        public string EmailAddress { get; set; }
        
        [Required(ErrorMessage = "Proszę podać temat wiadomości")]
        public string MessageSubject { get; set; }

        [Required(ErrorMessage = "Proszę wpisac treść wiadomości")]
        public string MessageContent { get; set; }
    }
}