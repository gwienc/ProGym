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

        public ActionResult Index(string categoryname, string searchQuery = null)
        {
            if ((categoryname == null || categoryname == "Wszystkie") && searchQuery == null)
            {
                var products = db.Products.ToList();
                return View(products);
            }

            else if ((categoryname == "Wszystkie" || categoryname == null) && searchQuery != null)
            {
                var products = db.Products.Where(p => (p.Name.ToLower().Contains(searchQuery.ToLower()) || p.ProducerName.ToLower().Contains(searchQuery.ToLower())) && !p.IsHidden);

                if (Request.IsAjaxRequest())
                {
                    return PartialView("_ProductList", products);
                }
                return View(products);
            }        
            else
            {
                var category = db.Categories.Include("Products").Where(c => c.CategoryName.ToUpper() == categoryname.ToUpper()).Single();
                var products = category.Products.Where(p => (searchQuery == null || p.Name.ToLower().Contains(searchQuery.ToLower()) || p.ProducerName.ToLower().Contains(searchQuery.ToLower())) && !p.IsHidden);

                if (Request.IsAjaxRequest())
                {
                    return PartialView("_ProductList", products);
                }
                return View(products);
            }

        }


        public ActionResult Details(int id)
        {
            var product = db.Products.Find(id);
            return View(product);
        }

        [ChildActionOnly]
        [OutputCache(Duration = 86400)]
        public ActionResult CategoriesMenu()
        {
            var categories = db.Categories.ToList();
            return PartialView("_CategoriesMenu", categories);
        }


        public ActionResult ProductsSuggestions(string term)
        {
            var products = this.db.Products.Where(p => !p.IsHidden && p.Name.ToLower().Contains(term.ToLower())).Take(5).Select(p => new { label = p.Name });

            return Json(products, JsonRequestBehavior.AllowGet);
        }
    }
}