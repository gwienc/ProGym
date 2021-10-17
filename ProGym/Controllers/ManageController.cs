using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProGym.Controllers
{
    public class ManageController : Controller
    {
        public enum ManageMessageId
        {
            ChangePasswordSuccess,          
            Error
        }


        public ActionResult Index()
        {
            return View();
        }
    }
}