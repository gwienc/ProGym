using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProGym.ViewModels
{
    public class BMIViewModel
    {
        public double Weight { get; set; }
        public double Height { get; set; }
        public double Result { get; set; }
        public string Range { get; set; }
    }
}