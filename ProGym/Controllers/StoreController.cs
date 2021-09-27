using ProGym.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProGym.Controllers
{
    public class StoreController : Controller
    {
        StoreContext db = new StoreContext();
        
        public ActionResult Index(string categoryname = "Wszystkie")
        {
            if (categoryname == "Wszystkie")
            {
                var products = db.Products.ToList();
                return View (products);
            }
            else
            {
                var category = db.Categories.Include("Products").Where(c => c.CategoryName.ToUpper() == categoryname.ToUpper()).Single();
                var products = category.Products.ToList();
                return View(products);
            }
         
        }

  
        public ActionResult Details(int id)
        {
            var product = db.Products.Find(id);
            return View(product);
        }

        [ChildActionOnly]
        public ActionResult CategoriesMenu()
        {
            var categories = db.Categories.ToList();
            return PartialView("_CategoriesMenu",categories);
        }
    }
}