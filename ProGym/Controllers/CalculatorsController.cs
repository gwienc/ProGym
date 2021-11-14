using ProGym.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProGym.Controllers
{
    public class CalculatorsController : Controller
    {
        // GET: Calculators
        public ActionResult Index()
        {          
            return View();
        }

        public PartialViewResult CalculateBMI(BMIViewModel model)
        {
            model.Height = model.Height * 0.01;
            model.Result = model.Weight / (model.Height*model.Height);

            if (model.Result < 16)
            {
                model.Range = "Wyglodzenie";
                
            }
            else if (model.Result > 16 && model.Result < 16.99)
            {
                model.Range = "Wychudzenie";
            }
            else if (model.Result > 17 && model.Result < 18.49)
            {
                model.Range = "Niedowaga";
            }
            else if (model.Result > 18.5 && model.Result < 24.99)
            {
                model.Range = "Prawidłowa masa ciała";
            }
            else if (model.Result > 25 && model.Result < 29.99)
            {
                model.Range = "Nadwaga";
            }
            else if (model.Result > 30 && model.Result < 34.99)
            {
                model.Range = "Otyłość I stopnia";
            }
            else if (model.Result > 35 && model.Result < 39.99)
            {
                model.Range = "Otyłość II stopnia";
            }
            else if (model.Result >= 40)
            {
                model.Range = "Otyłość III stopnia chorobliwa";
            }

            return PartialView("_CalculateBMI", model);

        }
    }
}