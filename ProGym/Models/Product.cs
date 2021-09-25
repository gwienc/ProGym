using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProGym.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public string ProducerName { get; set; }
        public decimal Price { get; set; }
        public string Ingredients { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public string Parameters { get; set; }
        public string PhotoFileName { get; set; }
        public DateTime DateAdded { get; set; }
        public bool IsHidden { get; set; }


        public virtual Category Category { get; set; }

    }
}