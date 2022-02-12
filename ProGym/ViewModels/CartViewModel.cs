using ProGym.Models;
using System.Collections.Generic;

namespace ProGym.ViewModels
{
    public class CartViewModel
    {
        public List<CartItem> CartItems { get; set; }
        public decimal TotalPrice { get; set; }
    }
}