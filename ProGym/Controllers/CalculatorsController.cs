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
            ViewBag.Purposes = model.Purposes;
            ViewBag.Types = model.Types;

            return View();
        }

        public JsonResult CalculateBMI(CalculatorsViewModel model)
        {
            model.Height = model.Height * 0.01;
            model.ResultBMI = model.Weight / (model.Height * model.Height);

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

        public JsonResult CalculateBMR(CalculatorsViewModel model)
        {
            switch (model.Gender.ToString())
            {
                case "M":
                    //model.ResultBMR = 66.5 + (13.7 * model.Weight) + (5 * model.Height) - (6.8 * model.Age);
                    model.ResultBMR = (9.99 * model.Weight) + (6.25 * model.Height) - (4.92 * model.Age) + 5;
                    break;
                case "K":
                    model.ResultBMR = (9.99 * model.Weight) + (6.25 * model.Height) - (4.92 * model.Age) - 161;
                    break;
                default:
                    break;
            }

            double sameWeight = 0;

            switch (model.ActivityID)
            {
                case 1:
                    sameWeight = model.ResultBMR * 1;
                    break;
                case 2:
                    sameWeight = model.ResultBMR * 1.2;
                    break;
                case 3:
                    sameWeight = model.ResultBMR * 1.4;
                    break;
                case 4:
                    sameWeight = model.ResultBMR * 1.6;
                    break;
                case 5:
                    sameWeight = model.ResultBMR * 1.8;
                    break;
                case 6:
                    sameWeight = model.ResultBMR * 2;
                    break;
                default:
                    break;
            }
           
            switch (model.PurposeID)
            {
                case 1:
                    if (model.TypeID == 1)
                    {
                        model.TotalCaloricRequirement = sameWeight + (0.2 * sameWeight);
                    }
                    else if (model.TypeID == 2)
                    {
                        model.TotalCaloricRequirement = sameWeight + (0.1 * sameWeight);
                    }
                    else if (model.TypeID == 3)
                    {
                        model.TotalCaloricRequirement = sameWeight + (0.15 * sameWeight);
                    }
                    break;
                case 2:
                    model.TotalCaloricRequirement = sameWeight;
                    break;
                case 3:
                    if (model.TypeID == 1)
                    {
                        model.TotalCaloricRequirement = sameWeight - (0.1 * sameWeight);
                    }
                    else if (model.TypeID == 2)
                    {
                        model.TotalCaloricRequirement = sameWeight - (0.2 * sameWeight);
                    }
                    else if (model.TypeID == 3)
                    {
                        model.TotalCaloricRequirement = sameWeight - (0.15 * sameWeight);
                    }
                    break;
                default:
                    break;
            }
            model.TotalCaloricRequirement = Math.Round(model.TotalCaloricRequirement, 3);
            model.ResultBMR = Math.Round(model.ResultBMR, 3);
            return Json(model);

        }

        public JsonResult CalculatePerfectWeight(CalculatorsViewModel model)
        {
            switch (model.Gender)
            {
                case 'M':
                    model.PerfectWeightLorentz = model.Height - 100 - ((model.Height - 150) / 4);
                    model.PerfectWeightBroc = (model.Height - 100) * 0.9;
                    model.PerfectWeightPotton = model.Height - 100 - (model.Height - 100) / 20;
                    break;
                case 'K':
                    model.PerfectWeightLorentz = model.Height - 100 - ((model.Height - 150) / 2);
                    model.PerfectWeightBroc = (model.Height - 100) * 0.85;
                    model.PerfectWeightPotton = model.Height - 100 - (model.Height - 100) / 10;
                    break;
                default:
                    break;
            }

            return Json(model);
        }

        public JsonResult CalculateBodyFatIndex(CalculatorsViewModel model)
        {
            var a = 4.15 * model.Waist;
            var b = a / 2.54;
            var c = 0.082 * model.Weight * 2.2;
            double d;
            double e;
            switch (model.Gender)
            {
                case 'M':
                    d = b - c - 98.42;
                    e = model.Weight * 2.2;
                    model.BodyFatIndex = d / e * 100;
                    model.BodyFatIndex = Math.Round(model.BodyFatIndex, 2);
                    break;
                case 'K':
                    d = b - c - 76.76;
                    e = model.Weight * 2.2;
                    model.BodyFatIndex = d / e * 100;
                    model.BodyFatIndex = Math.Round(model.BodyFatIndex, 2);
                    break;
                default:
                    break;
            }
            return Json(model);
        }
    }
}