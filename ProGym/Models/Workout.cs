using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProGym.Models
{
    public class Workout
    {
        public int WorkoutID { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<Exercise> Exercises { get; set; }
    }
}