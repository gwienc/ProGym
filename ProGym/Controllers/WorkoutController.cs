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
    }
}