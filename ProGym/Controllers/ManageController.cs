using Hangfire;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using ProGym.App_Start;
using ProGym.DAL;
using ProGym.Infrastructure;
using ProGym.Models;
using ProGym.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ProGym.Controllers
{
    public class ManageController : Controller
    {

        StoreContext db = new StoreContext();
        
        public enum ManageMessageId
        {
            ChangePasswordSuccess,          
            Error
        }

        private IMailService mailService;

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

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }


        public ManageController(IMailService mailService)
        {
            this.mailService = mailService;
        }

        public async Task<ActionResult> Index(ManageMessageId? message)
        {
            if(TempData["ViewData"] != null)
            {
                ViewData = (ViewDataDictionary)TempData["ViewData"];
            }

            if (User.IsInRole("Admin"))
                ViewBag.UserIsAdmin = true;
            else
                ViewBag.UserIsAdmin = false;

            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            if(user == null)
            {
                return View("Error");
            }
          
            var model = new ManageCredentialsViewModel
            {
                Message = message,
                HasPassword = this.HasPassword(),
                UserData = user.UserData
            };


            return View(model);
        }

        public async Task<ActionResult> GetProfile()
        {
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            Ticket ticket;

            if (user.Tickets != null && user.Tickets.Count != 0)
            {
               ticket = db.Tickets.Include("TypeOfTicket").Where(c => c.UserId == user.Id).Single();
                var model = new ProfileViewModel
                {
                    UserData = user.UserData,
                    Ticket = ticket
                };
                return View(model);
            }
            else
            {              
                var model = new ProfileViewModel
                {
                    UserData = user.UserData
                };
                return View(model);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangeProfile([Bind(Prefix = "UserData")] UserData userData)
        {
            if(ModelState.IsValid)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                user.UserData = userData;
                var result = await UserManager.UpdateAsync(user);

                AddErrors(result);
            }

            if(!ModelState.IsValid)
            {
                TempData["ViewData"] = ViewData;
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword([Bind(Prefix = "ChangePasswordViewModel")]ChangePasswordViewModel model)
        {
            if(!ModelState.IsValid)
            {
                TempData["viewData"] = ViewData;
                return RedirectToAction("Index");
            }

            var result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);
            if(result.Succeeded)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                if(user != null)
                {
                    await SignInAsync(user, isPersistent: false);
                }
                return RedirectToAction("Index", new { Message = ManageMessageId.ChangePasswordSuccess});
            }

            AddErrors(result);

            if (!ModelState.IsValid)
            {
                TempData["ViewData"] = ViewData;
                return RedirectToAction("Index");
            }

            var message = ManageMessageId.ChangePasswordSuccess;
            return RedirectToAction("Index", new { Message = message });
        }


        public ActionResult OrdersList(Order orders)
        {
            bool isAdmin = User.IsInRole("Admin");
            ViewBag.UserIsAdmin = isAdmin;
            IEnumerable<Order> userOrders;

            if (isAdmin)
            {
                userOrders = db.Orders.Include("OrderItems").OrderByDescending(o => o.DateCreated).ToArray();
            }
            else
            {
                var userId = User.Identity.GetUserId();
                userOrders = db.Orders.Where(o => o.UserId == userId).Include("OrderItems").OrderByDescending(o => o.DateCreated).ToArray();
            }
           
            return View(userOrders);
        }


        public OrderState ChangeOrderState(Order order)
        {
            Order orderToModify = db.Orders.Find(order.OrderID);
            orderToModify.OrderState = order.OrderState;
            db.SaveChanges();
            
            if(orderToModify.OrderState == OrderState.Completed)
            {
                
                this.mailService.SendOrderPreparedEmail(orderToModify);
            }
            else if (orderToModify.OrderState == OrderState.Received)
            {
                
                this.mailService.SendOrderReceivedEmail(orderToModify);
            }

            return order.OrderState;
        }


        public ActionResult AddProduct(int? productId, bool? confirmSuccess)
        {
            Product product;

            if(productId.HasValue)
            {
                ViewBag.EditMode = true;
                product = db.Products.Find(productId);
            }
            else
            {
                ViewBag.EditMode = false;
                product = new Product();
            }

            var result = new AddOrEditProductViewModel();
            result.Categories = db.Categories.ToList();

            result.Product = product;
            result.ConfirmSuccess = confirmSuccess;

            return View(result);
        }

        [HttpPost]
        public ActionResult AddProduct(AddOrEditProductViewModel model, HttpPostedFileBase file)
        {

            if (model.Product.ProductID > 0)
            {
                db.Entry(model.Product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("AddProduct", new { confirmSuccess = true });
            }
            else
            {


                if (file != null && file.ContentLength > 0)
                {

                    if (ModelState.IsValid)
                    {
                        var fileExt = Path.GetExtension(file.FileName);
                        var fileName = Guid.NewGuid() + fileExt;

                        var path = Path.Combine(Server.MapPath(AppConfig.PhotosFolder), fileName);
                        file.SaveAs(path);


                        model.Product.PhotoFileName = fileName;
                        model.Product.DateAdded = DateTime.Now;

                        db.Entry(model.Product).State = EntityState.Added;
                        db.SaveChanges();


                        return RedirectToAction("AddProduct", new { confirmSuccess = true });
                    }
                    else
                    {
                        ModelState.AddModelError("", "Nie wskazano pliku");
                        var categories = db.Categories.ToArray();
                        model.Categories = categories;


                        return View(model);
                    }

                }
                else
                {
                    var categories = db.Categories.ToArray();
                    model.Categories = categories;


                    return View(model);
                }
            }
        }
        public ActionResult GetAllProducts()
        {
            var allProducts = db.Products.ToList();
            return View(allProducts);
        }

        public ActionResult UsersList()
        {
            string adminName = "admin@ProGym.pl";           
            ViewBag.UserIsAdmin = adminName;
            var allUsers = db.Users.ToList();
            return View(allUsers);
        }

        [HttpPost]
        public ActionResult HideProduct(int? productId)
        {
            var product = db.Products.Find(productId);
            product.IsHidden = true;
            db.SaveChanges();

            return RedirectToAction("AddProduct", new { confirmSuccess = true });
        }

        [HttpPost]
        public ActionResult UnhideProduct(int productId)
        {
            var product = db.Products.Find(productId);
            product.IsHidden = false;
            db.SaveChanges();

            return RedirectToAction("AddProduct", new { confirmSuccess = true });
        }

        public ActionResult SendConfirmationEmail(int orderid, string lastname)
        {
            var order = db.Orders.Include("OrderItems").Include("OrderItems.Product").SingleOrDefault(o => o.OrderID == orderid && o.LastName == lastname);
            
            if (order == null) return new HttpStatusCodeResult(System.Net.HttpStatusCode.NotFound);

            OrderConfirmationEmail email = new OrderConfirmationEmail();
            email.To = order.Email;
            email.Name = order.FirstName;
            email.Cost = order.TotalPrice;
            email.OrderNumber = order.OrderID;
            email.OrderItems = order.OrderItems;
            email.CoverPath = AppConfig.PhotosFolder;
            email.Send();

            return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
        }

        public ActionResult SendPreparedOrderEmail(int orderid, string lastname)
        {
            var order = db.Orders.Include("OrderItems").Include("OrderItems.Product").SingleOrDefault(o => o.OrderID == orderid && o.LastName == lastname);
            if (order == null) return new HttpStatusCodeResult(System.Net.HttpStatusCode.NotFound);

            OrderPreparedEmail email = new OrderPreparedEmail();
            email.To = order.Email;
            email.Name = order.FirstName;
            email.Cost = order.TotalPrice;
            email.OrderNumber = order.OrderID;
            email.OrderItems = order.OrderItems;
            email.CoverPath = AppConfig.PhotosFolder;
            email.Send();

            return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
        }

        public ActionResult SendReceivedOrderEmail(int orderid, string lastname)
        {
            var order = db.Orders.Include("OrderItems").Include("OrderItems.Product").SingleOrDefault(o => o.OrderID == orderid && o.LastName == lastname);
            if (order == null) return new HttpStatusCodeResult(System.Net.HttpStatusCode.NotFound);

            OrderReceivedEmail email = new OrderReceivedEmail();
            email.To = order.Email;
            email.Name = order.FirstName;
            email.OrderNumber = order.OrderID;
            email.OrderItems = order.OrderItems;
            email.CoverPath = AppConfig.PhotosFolder;
            email.Send();

            return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
        }

        public ActionResult SendConfirmationTicketEmail(int ticketId, string userId)
        {
            var ticket = db.Tickets.Include("TypeOfTicket").SingleOrDefault(t => t.TicketId == ticketId && t.UserId == userId);
            if(ticket == null) return new HttpStatusCodeResult(System.Net.HttpStatusCode.NotFound);

            TicketConfirmationEmail email = new TicketConfirmationEmail();
            email.To = ticket.User.UserData.Email;
            email.Name = ticket.User.UserData.FirstName;
            email.TicketName = ticket.TypeOfTicket.TypeTicket.ToString();
            email.TicketID = ticket.TicketId;
            email.ExpirationDate = ticket.ExpirationDate;
            email.PeriodOfValidity = ticket.TypeOfTicket.PeriodOfValidity;
            email.Send();

            return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
        }


        private bool HasPassword()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            if (user != null)
            {
                return user.PasswordHash != null;
            }
            return false;
        }



        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("password-error", error);
            }
        }

        private async Task SignInAsync(ApplicationUser user, bool isPersistent)
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie, DefaultAuthenticationTypes.TwoFactorCookie);
            AuthenticationManager.SignIn(new AuthenticationProperties { IsPersistent = isPersistent }, await user.GenerateUserIdentityAsync(UserManager));
        }
    }
}