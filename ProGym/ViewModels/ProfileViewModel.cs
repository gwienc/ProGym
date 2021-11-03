using ProGym.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProGym.ViewModels
{
    public class ProfileViewModel
    {
        public UserData UserData { get; set; }
        public Ticket Ticket { get; set; }
    }
}