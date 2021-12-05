using Hangfire;
using ProGym.DAL;
using ProGym.Infrastructure;
using ProGym.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProGym.Controllers
{
    public class HomeController : Controller
    {     
        // GET: Home
        public ActionResult Index()
        { 
            return View();
        }

        [OutputCache(Duration =86400)]
        public ActionResult StaticContent(string viewname)
        {
            return View(viewname);
        }

        [HttpPost]
        public ActionResult SendContactMessage(ContactEmail email)
        {

            return RedirectToAction("StaticContent", new { viewname = "Contact" });
        }
    }
}