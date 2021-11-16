using System;
using System.Collections.Generic;
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
        public double Weight { get; set; }
        public double Height { get; set; }
        public double ResultBMI { get; set; }
        public string Range { get; set; }
        public int NumberOfRepetitions { get; set; }
        public double ResultRepMax { get; set; }
        public char Gender { get; set; }
        public int Age { get; set; }
        public int ActivityID { get; set; }
        public List<Activity> Activities
        {
            get
            {
                return new List<Activity>()
                {
                    new Activity() {ID = 1, Description = "Znikoma aktywność fizyczna (brak ćwiczeń oraz siedzący tryb życia"},
                    new Activity() {ID = 2, Description = "Niska aktywność fizyczna (siedzący tryb życia oraz częste spacery lub 1-2 treningi w tygodniu"},
                    new Activity() {ID = 3, Description = "Średnia aktywność fizyczna (praca fizyczna lub siedzący tryb życia i 2-4 treningi w tygodniu"},
                    new Activity() {ID = 4, Description = "Wysoka aktywność fizyczna (ciężka praca fizyczna lub kilka ciężkich treningów w tygodniu"},
                };

            }
        }
    }

    public class Activity
    {
        public int ID { get; set; }
        public string Description { get; set; }
    }
}