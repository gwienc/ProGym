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
        public decimal Cost { get; set; }
        public int OrderNumber { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public string CoverPath { get; set; }
    }
}