using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using ProGym.App_Start;
using ProGym.DAL;
using ProGym.Infrastructure;
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
        StoreContext db;
        private IMailService _mailService;
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

        public TicketController(IMailService mailService, StoreContext db)
        {
            _mailService = mailService;
            this.db = db;
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
            TypeOfTicket typeOfTicket = db.TypeOfTickets.Where(t => t.TypeOfTicketId == ticketId && t.TypeTicket == typeTicket && t.PeriodOfValidity == periodOfValidity).Single();

            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());

            DateTime dateofPurchase = DateTime.Now;
            if (Request.IsAuthenticated)
            {
                var currentTicket = db.Tickets.Where(t => t.UserId == user.Id).FirstOrDefault();

                if (currentTicket != null && currentTicket.IsActive)
                {
                    ViewBag.CurrentTicket = "Posiadasz aktualny karnet";
                    return View();
                }
                else
                {
                    Ticket newTicket = new Ticket();

                    switch (periodOfValidity)
                    {
                        case PeriodOfValidity.OneMonth:
                            newTicket = new Ticket()
                            {
                                TypeOfTicket = typeOfTicket,
                                TypeOfTicketId = typeOfTicket.TypeOfTicketId,
                                DateOfPurchase = dateofPurchase,
                                ExpirationDate = dateofPurchase.AddMonths(1),
                                IsActive = true

                            };
                            break;
                        case PeriodOfValidity.ThreeMonth:
                            newTicket = new Ticket
                            {
                                TypeOfTicket = typeOfTicket,
                                TypeOfTicketId = typeOfTicket.TypeOfTicketId,
                                DateOfPurchase = dateofPurchase,
                                ExpirationDate = dateofPurchase.AddMonths(3),
                                IsActive = true
                            };
                            break;
                        case PeriodOfValidity.SixMonth:
                            newTicket = new Ticket
                            {
                                TypeOfTicket = typeOfTicket,
                                TypeOfTicketId = typeOfTicket.TypeOfTicketId,
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
            }
            else
            {
                return RedirectToAction("Login", "Account", new { returnUrl = Url.Action("BuyTicket", "Ticket", new { ticketId = ticketId, typeTicket = typeTicket, periodOfValidity = periodOfValidity }) });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> BuyTicket(Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();

                var currentTicket = db.Tickets.Where(t => t.UserId == userId).FirstOrDefault();

                if (currentTicket != null)
                {
                    Ticket updateTicket = UpdateTicket(userId, ticket);
                    var user = await UserManager.FindByIdAsync(userId);
                    TryUpdateModel(user.Tickets);
                    _mailService.SendConfirmationTicketEmail(updateTicket);
                    return RedirectToAction("OrderConfirmation", "Cart");
                }
                else
                {
                    Ticket newTicket = CreateTicket(userId, ticket);

                    var user = await UserManager.FindByIdAsync(userId);
                    TryUpdateModel(user.Tickets);
                    await UserManager.UpdateAsync(user);

                    _mailService.SendConfirmationTicketEmail(newTicket);

                    return RedirectToAction("OrderConfirmation", "Cart");
                }
            }
            else
            {
                return View(ticket);
            }
        }

        public Ticket CreateTicket(string userId, Ticket ticket)
        {
            Ticket newTicket = new Ticket()
            {
                UserId = userId,
                DateOfPurchase = ticket.DateOfPurchase,
                ExpirationDate = ticket.ExpirationDate,
                IsActive = !ticket.IsActive,
                TypeOfTicketId = ticket.TypeOfTicketId
            };
            this.db.Tickets.Add(newTicket);
            db.SaveChanges();

            return newTicket;
        }

        public Ticket UpdateTicket(string userId, Ticket ticket)
        {
            var updateTicket = db.Tickets.Where(t => t.UserId == userId).FirstOrDefault();
            updateTicket.DateOfPurchase = ticket.DateOfPurchase;
            updateTicket.ExpirationDate = ticket.ExpirationDate;
            updateTicket.IsActive = !ticket.IsActive;
            updateTicket.TypeOfTicketId = ticket.TypeOfTicketId;
            db.SaveChanges();

            return updateTicket;
        }
    }
}