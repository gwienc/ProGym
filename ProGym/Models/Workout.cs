using System;
using System.Collections.Generic;

namespace ProGym.Models
{
    public class Workout
    {
        public int WorkoutID { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<Exercise> Exercises { get; set; }
    }
}