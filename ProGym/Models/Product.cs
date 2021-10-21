using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProGym.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public int CategoryID { get; set; }
        [Display(Name = "Nazwa produktu")]
        [Required(ErrorMessage = "Proszę podać nazwę produktu")]
        public string Name { get; set; }
        [Display(Name = "Nazwa producenta")]
        [Required(ErrorMessage = "Proszę podać nazwę producenta")]
        public string ProducerName { get; set; }

        [Display(Name = "Cena")]
        [Required(ErrorMessage = "Proszę podać cenę")]
        public decimal Price { get; set; }
        
        [Required(ErrorMessage = "Proszę podać skład")]
        [Display(Name = "Skład")]
        public string Ingredients { get; set; }
        
        [Required(ErrorMessage = "Proszę podać opis")]
        [Display(Name = "Opis")]
        public string Description { get; set; }
        
        [Display(Name = "Skrócony opis")]
        [Required(ErrorMessage = "Proszę podać skrócony opis")]
        public string ShortDescription { get; set; }
        
        [Required(ErrorMessage = "Proszę podać parametry")]
        [Display(Name = "Parametry")]
        public string Parameters { get; set; }
        
        [Display(Name = "Zdjęcie")]
        [Required(ErrorMessage = "Proszę wczytać zdjęcie")]
        public string PhotoFileName { get; set; }
        public DateTime DateAdded { get; set; }
        public bool IsHidden { get; set; }


        public virtual Category Category { get; set; }

    }
}