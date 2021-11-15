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

    }
}