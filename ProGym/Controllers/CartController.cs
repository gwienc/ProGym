using Microsoft.AspNet.Identity;
using ProGym.DAL;
using ProGym.Infrastructure;
using ProGym.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using ProGym.App_Start;
using ProGym.Models;
using Hangfire;

namespace ProGym.Controllers
{
    public class CartController : Controller
    {
        private ShoppingCartManager shoppingCartManager;
        private ISessionManager sessionManager { get; set; }
        private StoreContext db = new StoreContext();
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

        
        
        
        public CartController()
        {
            this.sessionManager = new SessionManager();
            this.shoppingCartManager = new ShoppingCartManager(this.sessionManager, this.db);
        }
        // GET: Cart
        
        
        
        
        public ActionResult Index()
        {
            var cartItems = shoppingCartManager.GetCart();
            var cartTotalPrice = shoppingCartManager.GetCartTotalPrice();

            CartViewModel cartViewModel = new CartViewModel()
            {
                CartItems = cartItems,
                TotalPrice = cartTotalPrice
            };

            return View(cartViewModel);
        }

        public ActionResult AddToCart(int id)
        {
            shoppingCartManager.addToCart(id);

            return RedirectToAction("Index");
        }

        public int GetCartItemsCount()
        {
            return shoppingCartManager.GetCartItemsCount();
        }

        public ActionResult RemoveFromCart(int productID)
        {
            int itemCount = shoppingCartManager.RemoveFromCart(productID);
            int cartItemsCount = shoppingCartManager.GetCartItemsCount();
            decimal cartTotal = shoppingCartManager.GetCartTotalPrice();

            var result = new CartRemoveViewModel
            {
                RemoveItemId = productID,
                RemovedItemCount = itemCount,
                CartTotal = cartTotal,
                CartItemsCount = cartItemsCount
            };

            return Json(result);
        }

        public async Task<ActionResult> Checkout()
        {
            if (Request.IsAuthenticated)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());

                var order = new Order
                {
                    FirstName = user.UserData.FirstName,
                    LastName = user.UserData.LastName,
                    Address = user.UserData.Address,
                    CodeAndCity = user.UserData.CodeAndCity,
                    Email = user.UserData.Email,
                    PhoneNumber = user.UserData.PhoneNumber
                };

                return View(order);
            }
            else
            {
               return RedirectToAction("Login", "Account", new { returnUrl = Url.Action("Checkout", "Cart") });
            }

        }

        [HttpPost]
        public async Task<ActionResult> Checkout(Order orderdetails)
        {
            if(ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();

                var newOrder = shoppingCartManager.CreateOrder(orderdetails, userId);

                
                var user = await UserManager.FindByIdAsync(userId);
                TryUpdateModel(user.UserData);
                await UserManager.UpdateAsync(user);

                shoppingCartManager.EmptyCart();

                var order = db.Orders.Include("OrderItems").Include("OrderItems.Product").SingleOrDefault(o => o.OrderID == newOrder.OrderID);

                
                string url = Url.Action("SendConfirmationEmail", "Manage", new { orderid = newOrder.OrderID, lastname = newOrder.LastName }, Request.Url.Scheme);

                BackgroundJob.Enqueue(() => HelpersHangfire.CallUrl(url));
               

                return RedirectToAction("OrderConfirmation");
            }
            else
            {
                return View(orderdetails);
            }
        }

        public ActionResult OrderConfirmation()
        {
            return View();
        }
    }
}