using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProGym.Models
{
    public class TypeOfTicket
    {
        public int TypeOfTicketId { get; set; }
        public TypeTicket TypeTicket { get; set; }
        [Display(Name = "Okres aktywności")]
        public PeriodOfValidity PeriodOfValidity { get; set; }

    }

    public enum TypeTicket
    {
        Student,
        Open,
        OpenMax
    }

    public enum PeriodOfValidity
    {
        [Display(Name = "Miesiąc")]
        OneMonth,

        [Display(Name = "3 miesiące")]
        ThreeMonth,

        [Display(Name = "6 miesięcy")]
        SixMonth
    }
}