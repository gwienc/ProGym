using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using ProGym.App_Start;
using ProGym.DAL;
using ProGym.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ProGym.Controllers
{
    public class TicketController : Controller
    {
        StoreContext db = new StoreContext();

        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

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

        
        
        public async Task<ActionResult> BuyTicket(int ticketId, TypeTicket typeTicket, PeriodOfValidity periodOfValidity)
        {
            TypeOfTicket typeOfTicket = new TypeOfTicket()
            {
                TypeOfTicketId = ticketId,
                TypeTicket = typeTicket,
                PeriodOfValidity = periodOfValidity
            };
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());

            if (Request.IsAuthenticated)
            {
                var dateofPurchase = DateTime.Now;
                Ticket newTicket = new Ticket();

                switch (periodOfValidity)
                {
                    case PeriodOfValidity.OneMonth:
                        newTicket = new Ticket()
                        {
                            TypeOfTicket = typeOfTicket,                         
                            DateOfPurchase = dateofPurchase,
                            ExpirationDate = dateofPurchase.AddMonths(1),
                            IsActive = true

                        };
                        break;
                    case PeriodOfValidity.ThreeMonth:
                        newTicket = new Ticket
                        {
                            TypeOfTicket = typeOfTicket,
                            DateOfPurchase = dateofPurchase,
                            ExpirationDate = dateofPurchase.AddMonths(3),
                            IsActive = true
                        };
                        break;
                    case PeriodOfValidity.SixMonth:
                        newTicket = new Ticket
                        {
                            TypeOfTicket = typeOfTicket,
                            DateOfPurchase = dateofPurchase,
                            ExpirationDate = dateofPurchase.AddMonths(6),
                            IsActive = true
                        };
                        break;
                    default:
                        break;
                }
                return View(newTicket);
            }
            else
            {
                return RedirectToAction("Login", "Account", new { returnUrl = Url.Action("Checkout", "Cart") });
            }

        }

        [HttpPost]
        public async Task<ActionResult> BuyTicket(Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();

                CreateTicket(userId, ticket);

                var user = await UserManager.FindByIdAsync(userId);
                TryUpdateModel(user.Tickets);
                await UserManager.UpdateAsync(user);

                return RedirectToAction("OrderConfirmation", "Cart");
            }
            else
            {
                return View(ticket);
            }
        }


        public void CreateTicket(string userId, Ticket ticket)
        {
            Ticket newTicket = new Ticket()
            {
                UserId = userId,
                DateOfPurchase = ticket.DateOfPurchase,
                ExpirationDate = ticket.ExpirationDate,
                IsActive = ticket.IsActive,
                TypeOfTicket = ticket.TypeOfTicket,
            };
            this.db.Tickets.Add(newTicket);
            db.SaveChanges();
            
        }
    }
}