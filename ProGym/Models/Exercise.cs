namespace ProGym.Models
{
    public class Exercise
    {
        public int ExerciseID { get; set; }
        public string Name { get; set; }
        public int RepetitionsNumber { get; set; }
        public double Weight { get; set; }       
        public int WorkoutID { get; set; }
        public virtual Workout Workout { get; set; }
    }
}