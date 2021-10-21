using ProGym.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProGym.ViewModels
{
    public class AddOrEditProductViewModel
    {
        public Product Product { get; set; }
        [Display(Name = "Kategoria")]
        public IEnumerable<Category> Categories { get; set; }
        public bool? ConfirmSuccess { get; set; }
    }
}