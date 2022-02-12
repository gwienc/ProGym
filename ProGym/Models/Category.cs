using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProGym.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        [Display(Name = "Kategoria")]
        public string CategoryName { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}