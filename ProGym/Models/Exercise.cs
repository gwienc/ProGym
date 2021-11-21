using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProGym.Models
{
    public class Exercise
    {
        public int ExerciseID { get; set; }
        public string Name { get; set; }
        public int RepetitionsNumber { get; set; }
        public double Weight { get; set; }
        public virtual Workout Workout { get; set; }
    }
}