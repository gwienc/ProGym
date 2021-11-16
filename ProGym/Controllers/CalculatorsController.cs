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
            CalculatorsViewModel model = new CalculatorsViewModel();
            ViewBag.Activities = model.Activities;
            
            return View();
        }

        public JsonResult CalculateBMI(CalculatorsViewModel model)
        {
            model.Height = model.Height * 0.01;
            model.ResultBMI = model.Weight / (model.Height*model.Height);

            if (model.ResultBMI < 16)
            {
                model.Range = "Wyglodzenie";
                
            }
            else if (model.ResultBMI > 16 && model.ResultBMI < 16.99)
            {
                model.Range = "Wychudzenie";
            }
            else if (model.ResultBMI > 17 && model.ResultBMI < 18.49)
            {
                model.Range = "Niedowaga";
            }
            else if (model.ResultBMI > 18.5 && model.ResultBMI < 24.99)
            {
                model.Range = "Prawidłowa masa ciała";
            }
            else if (model.ResultBMI > 25 && model.ResultBMI < 29.99)
            {
                model.Range = "Nadwaga";
            }
            else if (model.ResultBMI > 30 && model.ResultBMI < 34.99)
            {
                model.Range = "Otyłość I stopnia";
            }
            else if (model.ResultBMI > 35 && model.ResultBMI < 39.99)
            {
                model.Range = "Otyłość II stopnia";
            }
            else if (model.ResultBMI >= 40)
            {
                model.Range = "Otyłość III stopnia chorobliwa";
            }

            return Json(model);

        }

        public JsonResult CalculateOneRepMax(CalculatorsViewModel model)
        {
            model.ResultRepMax = model.Weight * model.NumberOfRepetitions * model.ConstantValue + model.Weight;
            return Json(model);
        }
    }
}