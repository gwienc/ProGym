using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProGym.ViewModels
{
    public class CalculatorsViewModel
    {
        private const double _constantValue = 0.0333;
        public double ConstantValue
        {
            get
            {
                return _constantValue;
            }
        }
        [Required(ErrorMessage = "Proszę podać wagę")]
        public double Weight { get; set; }
        
        [Required(ErrorMessage = "Proszę podać wzrost")]
        public double Height { get; set; }
        public double ResultBMI { get; set; }
        public string Range { get; set; }
        [Required(ErrorMessage = "Proszę podać ilość powtórzeń")]
        public int NumberOfRepetitions { get; set; }
        public double ResultRepMax { get; set; }
        [Required(ErrorMessage = "Proszę wybrać płeć")]
        public char Gender { get; set; }
        [Required(ErrorMessage = "Proszę podać wiek")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Proszę wybrać rodzaj aktywności")]
        public double ActivityID { get; set; }
        [Required(ErrorMessage = "Proszę wybrać somatotyp")]
        public int TypeID { get; set; }
        [Required(ErrorMessage = "Proszę wybrać cel")]
        public int PurposeID { get; set; }
        public double ResultBMR { get; set; }
        public double PerfectWeightBroc { get; set; }
        public double PerfectWeightLorentz { get; set; }
        public double PerfectWeightPotton { get; set; }
        public double TotalCaloricRequirement { get; set; }
        public double BodyFatIndex { get; set; }
        [Required(ErrorMessage = "Proszę podać obwód pasa")]
        public double  Waist { get; set; }
        public List<Activity> Activities
        {
            get
            {
                return new List<Activity>()
                {
                    new Activity() {ID = 1, Description = "Leżący lub siedzący tryb życia, brak aktywności fizycznej"},
                    new Activity() {ID = 1.2, Description = "Praca siedząca, aktywność fizyczna na niskim poziomie"},
                    new Activity() {ID = 1.4, Description = "Praca niefizyczna, trening 2 razy w tygodniu"},
                    new Activity() {ID = 1.6, Description = "Lekka praca fizyczna, trening 3-4 razy w tygodniu"},
                    new Activity() {ID = 1.8, Description = "Praca fizyczna, trening 5 razy w tygodniu"},
                    new Activity() {ID = 2, Description = "Ciężka praca fizyczna, codzienny trening"}
                };

            }
        }
        public List<Type> Types
        {
            get
            {
                return new List<Type>()
                {
                    new Type() {ID =1, Description ="Ektomorfik"},
                    new Type() {ID =2, Description ="Endomorfik"},
                    new Type() {ID =3, Description ="Mezomorfik"}
                };
            }
        }

        public List<Purpose> Purposes
        {
            get
            {
                return new List<Purpose>()
                {
                    new Purpose(){ID = 1, Description ="Chcę nabrać masy"},
                    new Purpose(){ID = 2, Description ="Chcę utrzymać masę"},
                    new Purpose(){ID = 3, Description = "Chcę zredukować masę"}
                };
            }
        }
    }

    public class Activity
    {
        public double ID { get; set; }
        public string Description { get; set; }       
    }
    public class Type
    {
        public int ID { get; set; }
        public string Description { get; set; }
    }
    public class Purpose
    {
        public int ID { get; set; }
        public string Description { get; set; }
    }
}