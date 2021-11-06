using Postal;
using ProGym.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
        public string TicketName { get; set; }
        public DateTime ExpirationDate { get; set; }
        public PeriodOfValidity PeriodOfValidity { get; set; }
    }
}