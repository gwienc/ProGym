using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProGym.Controllers
{
    public class StoreController : Controller
    {
        // GET: Store
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details()
        {
            return View();
        }

        public ActionResult CategoriesMenu()
        {
            List<string> categories = new List<string>
            {
                "Wszystkie",
                "Pierwsza Kategoria",
                "Druga kategoria",
                "Trzecia Kategoria",
                "Czwarta kategoria",
                "Piąta kategoria",
                "Szósta kategoria"
            };
            return PartialView("_CategoriesMenu",categories);
        }
    }
}