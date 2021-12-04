using Microsoft.AspNet.Identity;
using ProGym.DAL;
using ProGym.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProGym.Controllers
{
    public class WorkoutController : Controller
    {
        StoreContext db = new StoreContext();
        public ActionResult Index()
        {

            IEnumerable<Workout> workouts = db.Workouts.Include("Exercises").ToList();
            return View(workouts);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveWorkout(string workoutName, Exercise[] exercises)
        {
            string result = "Błąd!";

            var userId = User.Identity.GetUserId();

            if (workoutName != null || exercises != null)
            {
                Workout newWorkout = new Workout()
                {
                    Name = workoutName,
                    CreateDate = DateTime.Now,
                    UserId = userId
                };
                db.Workouts.Add(newWorkout);
                db.SaveChanges();

                var workoutId = db.Workouts.OrderByDescending(w => w.WorkoutID).Select(r => r.WorkoutID).FirstOrDefault();
                foreach (var exercise in exercises)
                {
                    Exercise newExercise = new Exercise()
                    {
                        Name = exercise.Name,
                        RepetitionsNumber = exercise.RepetitionsNumber,
                        Weight = exercise.Weight,
                        WorkoutID = workoutId

                    };
                    db.Exercises.Add(newExercise);
                    
                }
                db.SaveChanges();
                result = "Sukces!";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult GetDetailsWorkout(int id)
        {
            IEnumerable<Exercise> exercises = db.Exercises.Where(e => e.WorkoutID == id);
            return PartialView("_GetDetailsWorkout",exercises);
        }
    }

}