using ProGym.DAL;
using ProGym.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProGym.Controllers
{
    public class TicketController : Controller
    {
        StoreContext db = new StoreContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ChooseTicket(string type)
        {
            IEnumerable<TypeOfTicket> tickets;
            tickets = db.TypeOfTickets.Where(t => t.TypeTicket.ToString().ToUpper() == type.ToUpper());
            return View(tickets);
        }
    }
}