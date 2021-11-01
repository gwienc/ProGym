using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProGym.Models
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public string UserId { get; set; }

        [Display(Name = "Data zakupu")]
        public DateTime DateOfPurchase { get; set; }

        [Display(Name = "Data ważności")]
        public DateTime ExpirationDate { get; set; }

        [Display(Name = "Rodzaj karnetu")]
        public TypeOfTicket TypeOfTicket { get; set; }

        [Display(Name = "Ważność")]
        public bool IsActive { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}