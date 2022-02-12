using System;
using System.ComponentModel.DataAnnotations;

namespace ProGym.Models
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public int TypeOfTicketId { get; set; }
        public string UserId { get; set; }

        [Display(Name = "Data zakupu")]
        public DateTime DateOfPurchase { get; set; }

        [Display(Name = "Data ważności")]
        public DateTime ExpirationDate { get; set; }

        [Display(Name = "Rodzaj karnetu")]
        public virtual TypeOfTicket TypeOfTicket { get; set; }

        [Display(Name = "Ważność")]
        public bool IsActive { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}